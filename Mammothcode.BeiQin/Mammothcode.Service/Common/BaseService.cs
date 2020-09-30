using Dapper.Linq;
using NLog;
using System.Collections;
using System.Collections.Generic;

namespace Mammothcode.Service
{
    public interface IService
    {
        IDbContext DbContext { get; set; }
        ILogger Logger { get; set; }
    }
    /// <summary>
    /// 顶级业务层
    /// </summary>
    public abstract class BaseService : System.IDisposable, IService
    {
        public IDbContext DbContext { get; set; }
        public ILogger Logger { get; set; }

        #region exception
        /// <summary>
        /// 主动抛出异常，使事务回滚
        /// </summary>
        /// <param name="message"></param>
        protected void ThrowServiceException(string message)
        {
            throw new ServiceException(message);
        }       
        #endregion

        #region response
        protected IResult IsOk(bool result)
        {
            var message = result ? "success" : "fail";
            return new OkResult
            {
                Result = result,
                Message = message,
                Status = result ? 200 : 409
            };
        }

        /// <summary>
        /// 抛出异常
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IResult ErrorMessage(string result)
        {
           
            return new OkResult
            {
                Result = false,
                Message = result,
                Status = false ? 200 : 409
            };
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        protected DataResult<T> Data<T>(T data, bool isok = true)
        {
            return new DataResult<T>
            {
                Data = data,
                Result = isok,
                Status = 200
            };
        }
        /// <summary>
        /// 返回数据，及总页数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        protected PageDatalResult<T> Data<T>(IEnumerable<T> list, long total)
        {
            return new PageDatalResult<T>
            {
                Data = list,
                Result = true,
                Status = 200,
                Total = total
            };
        }
        #endregion

        #region logger
        /// <summary>
        /// 日志【级别：1】：调试
        /// </summary>
        /// <param name="message"></param>
        protected void Debug(string message, string name = "service")
        {
            Logger?.Debug(message);
        }

        /// <summary>
        /// 日志【级别：2】：信息
        /// </summary>
        /// <param name="message"></param>
        protected void Info(string message, string name = "service")
        {
            Logger?.Info(message);
        }
        /// <summary>
        /// 日志【级别：4】：错误
        /// </summary>
        /// <param name="message"></param>
        protected void Error(string message, string name = "service")
        {
            Logger?.Error(message);
        }
        /// <summary>
        /// 日志【级别：0】：跟踪
        /// </summary>
        /// <param name="message"></param>
        protected void Trace(string message, string name = "service")
        {
            Logger?.Trace(message);
        }
        /// <summary>
        /// 日志【级别：3】：警告
        /// </summary>
        /// <param name="message"></param>
        protected void Warn(string message, string name = "service")
        {
            Logger?.Warn(message);
        }
        /// <summary>
        /// 日志【级别：5】：致命
        /// </summary>
        /// <param name="message"></param>
        protected void Fatal(string message, string name = "service")
        {
            Logger?.Fatal(message);
        }

        #endregion

        #region dispose
        public void Dispose()
        {
            DbContext?.Dispose();
        }
        #endregion
    }
}
