using Dapper.Linq;
using System;
using System.Linq.Expressions;

namespace Mammothcode.Service
{
    /// <summary>
    /// MySql函数
    /// </summary>
    public static class MySqlFun
    {      
        [Function]
        public static double? LOCATION_RANGE(double? lng1, double? lat1, double? lng2, double? lat2)
        {
            return 0;
        }      
        [Function]
        public static DateTime? DATE(DateTime? dateTime)
        {
            return dateTime;
        }    
        [Function]
        public static T2 IF<T1,T2>(Expression<Func<T1, bool>> expression, T2 val1, T2 val2)
        {
            return default;
        }
        [Function]
        public static DateTime NOW()
        {
            return default;
        }
        [Function]
        public static DateTime RAND()
        {
            return default;
        }
        [Function]
        public static T IFNULL<T>(object expr1, T expr2)
        {
            return default;
        }
      
        [Function]
        public static T COUNT<T>(T val)
        {
            return default;
        }    
        [Function]
        public static T SUM<T>(T val)
        {
            return default;
        }         
        [Function]
        public static T MAX<T>(T val)
        {
            return default;
        }               
        [Function]
        public static T DISTINCT<T>(T val)
        {
            return default;
        }
        [Function]
        public static string JSON_ARRAY_APPEND(string column, string path, object jsonValue)
        {
            return default(string);
        }
        [Function]
        public static string JSON_ARRAY_INSERT(string column, string path, object value)
        {
            return default(string);
        }
        [Function]
        public static string JSON_SET(string column, string path, object jsonValue)
        {
            return default(string);
        }
        [Function]
        public static string JSON_REMOVE(string column, string path)
        {
            return default(string);
        }
        [Function]
        public static string JSON_UNQUOTE(string column)
        {
            return default(string);
        }
        [Function]
        public static object JSON_QUOTE(string column)
        {
            return default(string);
        }
    }
}
