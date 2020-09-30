using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mammothcode.Model
{
    public class PageModel
    {
        /// <summary>
        /// 分页方式：0[普通分页]|1[下拉分页]
        /// </summary>
        public int PageType { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 是否返回分页总个数：1是，0否
        /// 默认1
        /// </summary>
        public int TakeCount { get; set; } = 1;
        /// <summary>
        /// 是否查询所有
        /// </summary>
        public int QueryAll { get; set; }
    }
    public class TokenModel
    {
        /// <summary>
        /// 用户Token
        /// </summary>
        [Required]
        public string Token { get; set; }
    }
    public class TokenPageModel:PageModel
    {
        /// <summary>
        /// 用户Token
        /// </summary>
        [Required]
        public string Token { get; set; }
    }
}
