using Castle.DynamicProxy;
using Dapper.Linq;
using Mammothcode.Library.Data;
using Mammothcode.Service;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Mammothcode.Service
{
    #region 服务工厂
    public static class ServiceFactory
    {
        private readonly static ProxyGenerator _proxyGenerator = new ProxyGenerator();
        private static DataSource _dataSource = null;
        /// <summary>
        /// 获取服务:内置事务和异常拦截栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>() where T : class, IService, new()
        {
            return GetService<T>(new TransactionIntercept());
        }
        /// <summary>
        /// 获取服务：内置事务和异常拦截栈+自定义栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>(params IInterceptor[] interceptors) where T : class, IService, new()
        {
            var list = interceptors.ToList();
            if (!list.Exists(s => s is TransactionIntercept))
            {
                list.Insert(0, new TransactionIntercept());
            }
            //if (!list.Exists(s => s is ServiceIntercept))
            //{
            //    list.Insert(0, new ServiceIntercept());
            //}
            //实例化服务
            var service = _proxyGenerator
              .CreateClassProxyWithTarget(new T(), list.ToArray());
            return service;
        }
        /// <summary>
        /// 配置数据源
        /// </summary>
        /// <param name="options"></param>
        public static void ConfigDbContext(Action<DataSource> options)
        {
            var datasource = new DataSource();
            options(datasource);
            Dapper.SqlMapper.TypeMapProvider = (type) => new LinqTypeMap(type);
            _dataSource = datasource;
        }
        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        public static IDbContext GetDbContext()
        {
            IDbContext dbcontext = new DbContext(_dataSource.ConnectionFacotry(), _dataSource.DatasourceType);
            if (_dataSource.UseProxy)
            {
                dbcontext = new DbContextProxy(dbcontext);
            }
            return dbcontext;
        }
    }
    #endregion

    #region 异常拦截【基础，功能：异常拦截】
    public class ServiceIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            ILogger serviceLogger = null;
            try
            {
                if (invocation.InvocationTarget is BaseService target)
                {
                    var loggerAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(ServiceLoggerAttribute), true).FirstOrDefault();
                    var name = loggerAttribute == null ? "service" : (loggerAttribute as ServiceLoggerAttribute).Name;
                    serviceLogger = LogManager.GetLogger(name);
                    target.Logger = serviceLogger;
                }
                invocation.Proceed();
            }
            catch (Exception e)
            {
                if (invocation.Method.ReturnType == typeof(IResult))
                {
                    invocation.ReturnValue = new ExceptionResult()
                    {
                        Exception = e.Message,
                        StackTrace = e is ServiceException ? "非法请求" : e.StackTrace,
                        Message = e is ServiceException ? e.Message : "请稍后再试",
                        Result = false,
                        Status = 500,
                    };
                }
                if (!(e is ServiceException))
                {
                    LogManager.GetLogger("exception").Error(e);
                }
                if (serviceLogger.Name != "service")//在有指定目录的日志中记录
                {
                    serviceLogger?.Error(e);
                }
            }
        }
    }

    #endregion

    #region 事务代理【扩展，功能：事务代理】
    public class TransactionIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            IDbContext dbContext = null;
            try
            {
                if (invocation.InvocationTarget is BaseService target)
                {

                    var serviceDbContextAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(ServiceDbContextAttribute), true).FirstOrDefault();
                    if (serviceDbContextAttribute != null)
                    {
                        var attribute = serviceDbContextAttribute as ServiceDbContextAttribute;
                        var tansaction = attribute.OpenTransaction;
                        var solationLevel = attribute.ISolationLevel == IsolationLevel.Unspecified ? null : attribute.ISolationLevel;
                        dbContext = ServiceFactory.GetDbContext();
                        dbContext.Open(tansaction, solationLevel);
                        target.DbContext = dbContext;
                        //实例化组件IComponent，并共用连接
                        if (invocation.TargetType.GetProperties().Any(a => a.PropertyType.GetInterface(nameof(IComponent)) != null))
                        {
                            var properties = invocation.TargetType.GetProperties().Where(a => a.PropertyType.GetInterface(nameof(IComponent)) != null);
                            foreach (var item in properties)
                            {
                                var component = (Activator.CreateInstance(item.PropertyType) as IComponent);
                                component.DbContext = target.DbContext;
                                item.SetValue(invocation.InvocationTarget, component);
                            }
                        }
                    }
                }
                invocation.Proceed();
                dbContext?.Commit();

            }
            catch (Exception e)
            {
                string strM = e.Message;
                dbContext?.Rollback();
                throw;
            }
            finally
            {
                dbContext?.Close();
            }
        }
    }
    #endregion
}