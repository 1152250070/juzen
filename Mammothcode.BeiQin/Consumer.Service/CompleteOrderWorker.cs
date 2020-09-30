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
            _logger = NLog.LogManager.GetLogger("取消接单");
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
                                .Set(a => a.OrderStatus, (int)OrderStatusEnum.未签到)
                                .Where(a => a.OrderStatus == (int)OrderStatusEnum.待上课)
                                .Where(a => a.OrderEndTime < myDate)
                                .Update();
                    var row2 = connection.From<MemberOrderCourse>()
                             .Set(a => a.OrderStatus, (int)OrderStatusEnum.取消)
                             .Where(a => a.OrderStatus == (int)OrderStatusEnum.排队中)
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
            //取消延时
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
