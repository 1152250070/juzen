using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammothcode.Service
{
    /// <summary>
    /// Service中方法中数据库上下文控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ServiceDbContextAttribute : Attribute
    {
        /// <summary>
        /// 是否使用事务
        /// </summary>
        public bool OpenTransaction { get; set; }
        /// <summary>
        /// 事物隔离级别
        /// </summary>
        public IsolationLevel? ISolationLevel { get; set; }      
        /// <summary>
        /// 是否在事务中执行
        /// </summary>
        /// <param name="transaction">是否在事务中执行</param>
        /// <param name="solationLevel">事务隔离级别</param>
        public ServiceDbContextAttribute(bool transaction = false, IsolationLevel solationLevel = IsolationLevel.Unspecified)
        {
            OpenTransaction = transaction;
            ISolationLevel = solationLevel;
        }
    }
    /// <summary>
    /// 日志选项:
    ///     用于个设置日志存放的目录：默认service
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ServiceLoggerAttribute : Attribute
    {
        public string Name { get; set; }
        public ServiceLoggerAttribute(string name)
        {
            Name = name;
        }
    }
}
