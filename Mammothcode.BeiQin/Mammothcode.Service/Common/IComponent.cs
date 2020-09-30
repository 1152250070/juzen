using Dapper.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mammothcode.Service
{
    /// <summary>
    /// 组件，增强服务
    /// </summary>
    public interface IComponent
    {
        IDbContext DbContext { get; set; }
         ILogger Logger { get; set; }
    }
    public abstract class BaseComponent : IComponent, IDisposable
    {
        public IDbContext DbContext { get ; set ; }
        public ILogger Logger { get; set; }
        public void Dispose()
        {
            DbContext?.Dispose();
        }

        protected void Debug(string message, string name = "service")
        {
            Logger?.Debug(message);
        }
    }
}
