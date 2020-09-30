using System;
using System.Collections.Generic;
using System.Text;

namespace Mammothcode.Wechat
{
    /// <summary>
    /// 模板消息
    /// </summary>
    public class TplMsgUtil
    {
        #region 公众号发送模板消息
        /// <summary>
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1433751277
        /// </summary>
        /// <param name="token"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SendH5Message(string token,string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", token);
            var item = new HttpItem();
            item.Set("appid", Wechat_Config.AppID);         
            var json = HttpUtil.Post(new HttpItem
            {
                ContentType = "application/json",
                Method = "POST",
                URL = url,
                Data = data
            }).Document;
            return json;
        }
        #endregion

    }
}
