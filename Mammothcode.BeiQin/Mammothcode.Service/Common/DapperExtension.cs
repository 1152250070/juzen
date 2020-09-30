using Mammothcode.Model;
using Dapper.Linq;
using Dapper.Linq.Util;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace Mammothcode.Service
{
    /// <summary>
    /// 用于对IQueryable接口的扩展
    /// </summary>
    public static class DapperExtension
    {
        #region 分页扩展
        /// <summary>
        /// 分页,并返回总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Dapper.Linq.IQueryable<T> Page<T>(this Dapper.Linq.IQueryable<T> queryable, PageModel model, out long total) where T : class, new()
        {
            total = 0;
            if (model.QueryAll == 1)
            {
                return queryable;
            }
            //是否返回个数
            if (model.TakeCount == 1)
            {
                total = queryable.Count();
            }
            //传统分页
            if (model.PageType == 0)
            {
                var indexrow = (model.PageIndex - 1) * model.PageSize;
                queryable.Skip(indexrow, model.PageSize);
            }
            else if (model.PageType == 1)
            {
                //id下拉分页:下一页更具上一页最大id向后查（指定开始位置，性能超高),此时pageIndex作为那个最大的id
                queryable.Take(model.PageSize);
                if (queryable is MySqlQuery<T> mysqlquery)
                {
                    total = queryable.Count();
                    var table = EntityUtil.GetTable<T>();
                    var idName = table.Columns.Find(f => f.ColumnKey == ColumnKey.Primary).ColumnName;
                    var operatorChar = mysqlquery._orderBuffer.ToString().Contains("DESC") ? "<" : ">";
                    var index = operatorChar == "<" && model.PageIndex == 0 ? int.MaxValue : model.PageIndex;
                    var whereprefix = mysqlquery._whereBuffer.Length > 0 ? " AND " : "";
                    mysqlquery._whereBuffer.Insert(0, string.Format("({0} {1} {2}){3}", idName, operatorChar, index, whereprefix));
                }
            }
            return queryable;
        }
        public static Dapper.Linq.IQueryable<T> Page<T>(this Dapper.Linq.IQueryable<T> queryable, PageModel model) where T : class, new()
        {
            return Page(queryable, model, out _);
        }
        #endregion

        #region 分页扩展
        /// <summary>
        /// 分页扩展
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IQueryable<T1, T2> Page<T1, T2>(this IQueryable<T1, T2> queryable, PageModel model, out long total) where T1 : class, new() where T2 : class, new()
        {
            total = 0;
            if (model.QueryAll != 1)
            {
                queryable.Page(model.PageIndex, model.PageSize, out total);
            }
            return queryable;
        }
        public static IQueryable<T1, T2> Page<T1, T2>(this IQueryable<T1, T2> queryable, PageModel model) where T1 : class, new() where T2 : class, new()
        {
            return Page(queryable, model, out _);
        }
        public static IQueryable<T1, T2, T3> Page<T1, T2, T3>(this IQueryable<T1, T2, T3> queryable, PageModel model, out long total) where T1 : class, new() where T2 : class, new() where T3 : class, new()
        {
            total = 0;
            if (model.QueryAll != 1)
            {
                queryable.Page(model.PageIndex, model.PageSize, out total);
            }
            return queryable;
        }
        public static IQueryable<T1, T2, T3> Page<T1, T2, T3>(this IQueryable<T1, T2, T3> queryable, PageModel model) where T1 : class, new() where T2 : class, new() where T3 : class, new()
        {
            return Page(queryable, model, out _);
        }
        #endregion

        #region Exists
        public static bool Exists<T>(this Dapper.Linq.IQueryable<T> queryable, Expression<Func<T, bool?>> expression, bool condition = true) where T : class, new()
        {
            return queryable.Where(expression, condition).Exists();
        }
        #endregion
    }
}
