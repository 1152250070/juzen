using System;
using System.Text;

namespace Mammothcode.Wechat
{
    public static class AuthUtil
    {

        #region 小程序：获取openid
        public static string GetUserToken(string js_code)
        {
            var item = new HttpItem();
            item.Set("appid", Wechat_Config.AppID);
            item.Set("secret", Wechat_Config.Secret);
            item.Set("js_code", js_code);
            item.Set("grant_type", "authorization_code");
            string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?{0}", item.ToUrl());
            var json = HttpUtil.Post(new HttpItem
            {
                Method = "GET",
                URL = url,
            }).Document;
            return json;
        }
        #endregion

        #region 获取AppToken:有效期7200s
        public static string GetAccessToken()
        {
            var item = new HttpItem();
            item.Set("grant_type", "client_credential");
            item.Set("appid", Wechat_Config.AppID);
            item.Set("secret", Wechat_Config.Secret);
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?{0}", item.ToUrl());
            var res = HttpUtil.Post(new HttpItem()
            {
                URL = url
            });
            return res.Document;
        }

        public static string GetAccessToken(string js_code)
        {
            var item = new HttpItem();
            item.Set("appid", Wechat_Config.AppID);
            item.Set("secret", Wechat_Config.Secret);
            item.Set("js_code", js_code);
            item.Set("grant_type", "authorization_code");
            string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?{0}", item.ToUrl());
            var json = HttpUtil.Post(new HttpItem
            {
                ContentType = "text/xml",
                Method = "GET",
                URL = url,
            }).Document;
            return json;
        }
        public static string GetH5AccessToken()
        {
            var item = new HttpItem();
            item.Set("grant_type", "client_credential");
            item.Set("appid", Wechat_Config.H5AppID);
            item.Set("secret", Wechat_Config.H5Secret);
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?{0}", item.ToUrl());
            var res = HttpUtil.Post(new HttpItem()
            {
                URL = url
            });
            return res.Document;
        }
        #endregion

        #region H5 构造获取code的URL以用于获取openid
        /**
         * http://mp.weixin.qq.com/wiki/17/c0f37d5704f0b64713d5d2c37b468d75.html
         * 
         * */
        public static string GetH5AuthUrl(string redirectUrl)
        {
            var item = new HttpItem();
            item.Set("appid", Wechat_Config.H5AppID);
            item.Set("redirect_uri", redirectUrl);
            item.Set("response_type", "code");
            item.Set("scope", "snsapi_userinfo");//snsapi_userinfo|snsapi_base
            item.Set("state", "STATE" + "#wechat_redirect");
            return string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?{0}", item.ToUrl());
        }
        #endregion

        #region H5：获取openid
        public static string GetH5UserToken(string code)
        {
            if (Wechat_Config.Debug)
            {
                return "{\"access_token\":\"10004\",\"openid\":\"456468787\"}";
            }
            var item = new HttpItem();
            item.Set("appid", Wechat_Config.H5AppID);
            item.Set("secret", Wechat_Config.H5Secret);
            item.Set("code", code);
            item.Set("grant_type", "authorization_code");
            var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?{0}", item.ToUrl());
            var res = HttpUtil.Post(new HttpItem()
            {
                Method = "GET",
                URL = url,
            });
            return res.Document;
        }
        #endregion

        #region H5：刷新openid
        public static string RefreshH5Token(string refreshToken)
        {
            var item = new HttpItem();
            item.Set("appid", Wechat_Config.AppID);
            item.Set("grant_type", "refresh_token");
            item.Set("refresh_token", "refreshToken");
            item.Set("appid", Wechat_Config.AppID);
            var url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?{0}", item.ToUrl());
            var res = HttpUtil.Post(new HttpItem()
            {
                URL = url
            });
            return res.Document;

        }
        #endregion

        #region H5：获取用户信息
        /*
         * 
         * https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140839
         * 
         * */
        public static string GetH5UserInfo(string accessToken, string openid)
        {
            if (Wechat_Config.Debug)
            {
                return Wechat_Config.UserInfoJson;
            }
            var item = new HttpItem();
            item.Set("access_token", accessToken);
            item.Set("openid", openid);
            item.Set("lang", "zh_CN");
            var url = string.Format("https://api.weixin.qq.com/sns/userinfo?{0}", item.ToUrl());
            var res = HttpUtil.Post(new HttpItem()
            {
                URL = url,
            });
            return res.Document;
        }
        public static string GetH5UserInfoSubscribe(string accessToken, string openid)
        {
            if (Wechat_Config.Debug)
            {
                return Wechat_Config.UserInfoJson;
            }
            var item = new HttpItem();
            item.Set("access_token", accessToken);
            item.Set("openid", openid);
            item.Set("lang", "zh_CN");
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?{0}", item.ToUrl());
            var res = HttpUtil.Post(new HttpItem()
            {
                URL = url,
            });
            return res.Document;
        }
        #endregion

        #region 获取收货地址
        /****
         * 
         *  string host = page.Request.Url.Host;
         *  string path = page.Request.Path;
         *  string queryString = page.Request.Url.Query;
         *  string url = "http://" + host + path + queryString;
         * 
         * */
        public static string GetAddress(string url, string accessToken)
        {
            var item = new HttpItem();
            item.Set("appid", Wechat_Config.AppID);
            item.Set("url", url);
            item.Set("timestamp", StringUtil.GetTimeStamp());
            item.Set("noncestr", StringUtil.GetNonceStr());
            item.Set("accesstoken", accessToken);
            var sing = StringUtil.GetSHA1(item.ToUrl());
            return sing;
        }
        #endregion

        #region 获取JSAPI门票：有效期7200s
        public static string GetJsApiTicket(string accessToken)
        {
            var item = new HttpItem();
            item.Set("access_token", accessToken);
            item.Set("type","jsapi");
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?{0}",item.ToUrl());
            var res = HttpUtil.Post(new HttpItem()
            {
                URL = url
            });
            return res.Document;
        }
        #endregion

    }
}
