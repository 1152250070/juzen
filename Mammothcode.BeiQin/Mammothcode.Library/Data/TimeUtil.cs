using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammothcode.Library.Data
{
    /// <summary>
    /// 时间处理
    /// </summary>
    public class TimeUtil
    {
        #region 时间戳
        /// <summary>
        /// 将日期转时间戳
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long ToTimestamp(DateTime datetime)
        {
            var timespan = datetime - new DateTime(1970, 01, 01, 08, 00, 00);
            return (long)timespan.TotalMilliseconds;
        }
        /// <summary>
        /// 将时间戳转时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime FromTimestamp(long timestamp)
        {
            TimeSpan timespan = new TimeSpan(timestamp);
            return new DateTime(1970, 01, 01, 08, 00, 00).AddMilliseconds(timestamp);
        }
        #endregion
    }
}
