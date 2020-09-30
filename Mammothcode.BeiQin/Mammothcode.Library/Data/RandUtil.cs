using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammothcode.Library.Data
{
    /// <summary>
    /// 随机码工具类
    /// </summary>
    public class RandUtil
    {
        /// <summary>
        /// 64位长度的全球唯一GUID
        /// </summary>
        /// <param name="format">“N”、“D”、“B”、“P”或“X”</param>
        /// <returns></returns>
        public static string GetGuid(string format = "N")
        {
            return Guid.NewGuid().ToString(format);
        }
        /// <summary>
        /// 获取20位长度的随机码
        /// </summary>
        /// <returns></returns>
        public static string GetTuid()
        {
            return string.Format("{0}{1}", DateTime.Now.ToString("yyMMddHHmmss"), GetNumber(8));
        }

        /// <summary>
        /// 获取12位长度的随机码
        /// </summary>
        /// <returns></returns>
        public static string GetTuid12()
        {
            return string.Format("{0}{1}", DateTime.Now.ToString("yyMMddHH"), GetNumber(4));
        }
        /// <summary>
        /// 创建随机数字
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetNumber(int length)
        {
            var arr = new List<char>();
            while (true)
            {
                var buffer = Guid.NewGuid().ToString("N");
                arr.AddRange(buffer.ToArray().Where(a => char.IsNumber(a)));
                if (arr.Count >= length)
                {
                    break;
                }
            }
            return string.Join("", arr.Take(length));
        }
    }
}
