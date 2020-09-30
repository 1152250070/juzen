using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using NLog;

namespace Consumer.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {          
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                //自动完成订单
                services.AddHostedService<CompleteOrderWorker>();
                //配置数据库连接
                Dapper.Linq.DbContextFactory.AddDataSource(new Dapper.Linq.DataSource()
                {
                    DatasourceType = Dapper.Linq.DatasourceType.MYSQL,
                    ConnectionFacotry = () => new MySql.Data.MySqlClient.MySqlConnection(hostContext.Configuration.GetSection("ConnectionStrings:mysql").Value),
                    UseProxy=true,
                });
            });
    }
}
