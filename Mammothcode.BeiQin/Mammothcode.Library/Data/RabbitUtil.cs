using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Mammothcode.Library.Data
{
    public static class RabbitUtil
    {
        private static IConnectionFactory _factory;
        private static IConnection _connection;
        private static string _connectionName;

        public static void Initialization(Action<ConnectionOption> options)
        {
            var option = new ConnectionOption();
            options(option);
            _factory = new ConnectionFactory()
            {
                HostName = option.HostName,
                VirtualHost = option.VirtualHost,
                UserName = option.UserName,
                Password = option.Password,
                AutomaticRecoveryEnabled = true,//自动恢复连接
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10),//重试恢复时间间隔
            };
            _connectionName = option.ConnectionName;
        }

        public static IModel CreateChannel()
        {
            if (_connection == null)
            {
                _connection = _factory.CreateConnection(_connectionName);
                _connection.ConnectionRecoveryError += (sender, e) =>
                {
                    _connection?.Close();
                    _connection = null;
                };
                _connection.ConnectionShutdown += (sender, e) =>
                {
                    _connection?.Close();
                    _connection = null;
                };
                _connection.ConnectionBlocked += (sender, e) =>
                {
                    _connection?.Close();
                    _connection = null;
                };
            }
            return _connection.CreateModel();
        }

        public static void PublishDelayMessage(string queueName, string exchange, string routingKey, int queueExpires, int messageExpires, byte[] body)
        {
            using (var channel = CreateChannel())
            {
                var args = new Dictionary<string, object>();
                args.Add("x-expires", queueExpires);
                args.Add("x-message-ttl", messageExpires);
                args.Add("x-dead-letter-exchange", exchange);
                args.Add("x-dead-letter-routing-key", routingKey);
                channel.QueueDeclare(queueName, true, false, false, args);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange: "",
                    routingKey: queueName,
                    basicProperties: properties,
                    body: body);
            }
        }
        public static void ConsumerDelayMessage(string exchange, string routingKey, EventHandler<BasicDeliverEventArgs> received, TaskCompletionSource<int> taskSource)
        {
            using (var channel = CreateChannel())
            {
                channel.ExchangeDeclare(exchange: exchange, type: "direct");
                var name = channel.QueueDeclare().QueueName;
                channel.QueueBind(name, exchange, routingKey);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += received;
                channel.BasicConsume(queue: name, autoAck: false, consumer: consumer);
                taskSource.Task.Wait();
            }
        }

    }
    public class ConnectionOption
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConnectionName { get; set; }
    }
}
