using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mammothcode.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer.Service
{
    public class CompleteOrderWorker : BackgroundService
    {
        private readonly NLog.ILogger _logger;
        private readonly TaskCompletionSource<int> _tcs;
        public CompleteOrderWorker()
        {
            _logger = NLog.LogManager.GetLogger("ȡ���ӵ�");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var connection = Dapper.Linq.DbContextFactory.GetDbContext())
                {
                    var time = DateTime.Now.AddMinutes(-60);
                    DateTime myDate = DateTime.Now;
                    var rows = connection.From<MemberOrderCourse>()
                                .Set(a => a.OrderStatus, (int)OrderStatusEnum.δǩ��)
                                .Where(a => a.OrderStatus == (int)OrderStatusEnum.���Ͽ�)
                                .Where(a => a.OrderEndTime < myDate)
                                .Update();
                    var row2 = connection.From<MemberOrderCourse>()
                             .Set(a => a.OrderStatus, (int)OrderStatusEnum.ȡ��)
                             .Where(a => a.OrderStatus == (int)OrderStatusEnum.�Ŷ���)
                             .Where(a => a.OrderStartTime < myDate)
                             .Update();
                    _logger.Info($"completed order rows:{rows}");
                }
                await Task.Delay(1000, stoppingToken);
            }

           


        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Info($"start CompleteOrderWorker!!!");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //ȡ����ʱ
            _logger.Info($"stop CompleteOrderWorker!!!");
            return base.StopAsync(cancellationToken);
        }
        public override void Dispose()
        {
            _logger.Info($"Worker disposed at: {DateTime.Now}");

            base.Dispose();
        }
    }
}
