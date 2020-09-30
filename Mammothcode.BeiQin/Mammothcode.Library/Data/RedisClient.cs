using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mammothcode.Library.Data
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer _connection = null;
        private static string _connectionString = null;
        /// <summary>
        /// 返回实时的连接字符串
        /// </summary>
        private static Func<string> ConnectionString { get; set; }
        /// <summary>
        /// 多线程可复用对象：线程安全的、自动更具实时配置动态重置连接对象
        ///     
        /// </summary>
        public static void Initialization(Func<string> func)
        {
            ConnectionString = func;
        }
        public static ConnectionMultiplexer Redis
        {
            get
            {
                //如果null，或者配置被修改
                if (_connection == null || ConnectionString() != _connectionString)
                {
                    _connection?.Close();
                    _connectionString = ConnectionString();
                    _connection = ConnectionMultiplexer.Connect(_connectionString);
                }
                //处理连接失败
                _connection.ConnectionFailed += (sender, args) =>
                {
                    _connectionString = null;
                };
                return _connection;
            }
        }
        public static ConnectionMultiplexer GetConnection()
        {
            return Redis;
        }
        public static bool StringSet(string key, string value, TimeSpan? timespan = null)
        {
            return Redis.GetDatabase().StringSet(key, value, timespan);
        }
        public static string StringGet(string key)
        {
            return Redis.GetDatabase().StringGet(key);
        }
    }

}
