using Mammothcode.Library.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammothcode.Library.API
{
    /// <summary>
    /// 微信订阅消息
    /// </summary>
    public static class WXDYMessages
    {
        public static string _apikey = "c52741b9b9abee299cf58e7974aabaaa";
        public static string SendWXMessages(string accessToken, string data)
        {
            
            #region 获取二维码
            var result = HttpUtil.Post(new HttpItem()
            {
                URL = " https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token=" + accessToken,
                Method = "Post",
                ContentType = "application/json",
                Data = data,
            });
            #endregion

            return result.Document;
        }

        public static string HttpPostAction(string data)
        {

           
            var result = HttpUtil.Post(new HttpItem()
            {
                URL = "http://60.191.247.118:83/WPMS/getPublicKey",
                Method = "Post",
                ContentType = "application/json",
                Data = data,
            });
           

            return result.Document;
        }
    }
}
