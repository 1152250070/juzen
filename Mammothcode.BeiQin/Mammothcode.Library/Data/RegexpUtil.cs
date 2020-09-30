using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mammothcode.Library.Data
{
    /// <summary>
    /// 正则工具
    /// </summary>
    public static class RegexpUtil
    {
        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string Match(this string input, string pattern, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.Match(input, pattern, options).Value;
        }
        /// <summary>
        /// 正则匹配，返回指定组名
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="groupName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string Match(this string input, string pattern, string groupName, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.Match(input, pattern, options).Groups[groupName].Value;
        }
        /// <summary>
        /// 正则匹配，返回指定的组下标
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="groupIndex"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string Match(this string input, string pattern, int groupIndex, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.Match(input, pattern, options).Groups[groupIndex].Value;
        }
        /// <summary>
        /// 正则匹配返回集合
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<string> Matches(this string input, string pattern, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.Matches(input, pattern, options).Cast<Match>().Select(s => s.Value).ToList();
        }
        /// <summary>
        ///  正则匹配返回指定组名集合
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="groupName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<string> Matches(this string input, string pattern, string groupName, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.Matches(input, pattern, options).Cast<Match>().Select(s => s.Groups[groupName].Value).ToList();
        }
        /// <summary>
        /// 正则匹配返回指定组下标集合
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="groupIndex"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<string> Matches(this string input, string pattern, int groupIndex, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.Matches(input, pattern, options).Cast<Match>().Select(s => s.Groups[groupIndex].Value).ToList();
        }
        /// <summary>
        /// 正则匹配返回指定组名的匿名集合
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="func"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<TResult> Matches<TResult>(this string input, string pattern, Func<GroupCollection, TResult> func, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.Matches(input, pattern, options).Cast<Match>().Select(s => func(s.Groups)).ToList();
        }
        /// <summary>
        /// 正则匹配，是否匹配
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsMatch(this string input, string pattern, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.IsMatch(input, pattern, options);
        }
        /// <summary>
        /// 正则替换
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string Replace(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input,pattern, replacement);
        }
    }
}
