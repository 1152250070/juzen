using Mammothcode.Library.Data;
using Mammothcode.Wechat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mammothcode.MicroService.Components
{
   public  class WechatComponent
    {
        public static string GetAccessToken()
        {
            var key = "xiaopu:wechat:accessToken";
            var accesstoken = RedisClient.StringGet(key);
            if (string.IsNullOrEmpty(accesstoken))
            {
                var tokenJson = AuthUtil.GetAccessToken();
                var tokenObj = tokenJson.FromJsonObject();
                accesstoken = tokenObj["access_token"].ToString();
                RedisClient.StringSet(key, accesstoken, TimeSpan.FromMinutes(110));
            }
            return accesstoken;
        }
        /// <summary>
        /// 重定向到微信服务器，已触发微信返回jscode
        /// </summary>
        /// <param name="url">通知地址</param>
        /// <returns></returns>
        public static string GetH5AuthUrl(string url)
        {
            return AuthUtil.GetH5AuthUrl(url);
        }
    }
}
