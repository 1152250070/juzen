using Mammothcode.Library.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammothcode.Library.API
{
    /// <summary>
    /// 云片短信验证
    /// </summary>
    public static class YunPianUtil
    {
        public static string _apikey = "e80d03e54d66742b84a49acf892b1122";
        public static string SendSingle(string mobile, string text)
        {
            var url = string.Format("https://sms.yunpian.com/v2/sms/single_send.json?apikey={0}&mobile={1}&text={2}", _apikey, mobile, text);

            var res = HttpUtil.Post(new HttpItem()
            {
                URL = url,
                Accept = "application/json;charset=utf-8;",
                ContentType = "application/x-www-form-urlencoded;charset=utf-8;",
                Method = "POST",
            });
            return res.Document;
        }
    }
}
