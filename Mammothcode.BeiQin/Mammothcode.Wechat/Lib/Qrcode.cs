using Mammothcode.Wechat;

namespace Mammothcode.Wechat
{
    public class Qrcode
    {
        public static byte[] GetQRCodeB(string accessToken,string data)
        {

            #region 获取二维码
            var result = HttpUtil.Post(new HttpItem()
            {
                URL = "https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token=" + accessToken,
                Method = "Post",
                ContentType= "application/json",
                Data= data,
            });
            #endregion

            return result.Bytes;
        }
    }
}
