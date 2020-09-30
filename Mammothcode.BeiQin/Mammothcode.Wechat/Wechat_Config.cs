using System;
using System.Web;

namespace Mammothcode.Wechat
{
    public static class Wechat_Config
    {
        #region 【基本信息设置】
        public static string AppID = "wx7e6170c038e4361d"; //APPID：绑定支付的APPID（必须配置）
        public static string Secret = "5da3154ad2125e08cf31d09ae0d85294";//APPSECRET
        public static string MchID = "1513758371";//MCHID：商户号（必须配置）
        public static string Key = "jiuxianjiuxianjiuxianjiuxian8888";//KEY：商户支付密钥（必须配置）
        public static string SignType = "MD5";//可选值[MD5|HMAC-SHA256]
        #endregion

        #region 【公众号设置】
        public static string H5AppID = "wx7677bec81130b484"; //APPID：绑定支付的APPID（必须配置）
        public static string H5Secret = "1cdc7b812ddfc6989f8a537c1c3c1dd9";//APPSECRET
        #endregion

        #region 【证书路径设置:仅退款、撤销订单时需要】
        public static string SSlCertFilename = @"\cert\1513758371_20180914_cert.p12";//路径
        public static string SSlCertPassword = "1513758371";//密码
        #endregion

        #region 【商户系统后台机器IP】
        public static string MchIP = "0.0.0.0";
        #endregion

        #region 【代理服务器设置】
        public static string ProxyUrl = "";
        #endregion

        #region 【调试模式】
        /// <summary>
        /// 调试模式：H5
        /// </summary>
        public static bool Debug = false;
        #endregion

        #region 【用户信息：用于调试】
        public static string UserInfoJson = "{\"openid\":\"osS3I1Ikj2KlO3PMe7Qwu0BLA9mA\",\"nickname\":\"我叫梁朝伟\",\"sex\":1,\"language\":\"zh_CN\",\"city\":\"宁波\",\"province\":\"浙江\",\"country\":\"中国\",\"headimgurl\":\"http:\\/\\/thirdwx.qlogo.cn\\/mmopen\\/vi_32\\/Q0j4TwGTfTLVZbOrTHSY6PKEJ8dSvyknKC2KC1m22Yo341b1QDdxFyJ9QBvh2xyDRIXWbyhEicXkkcVpygV106g\\/132\",\"privilege\":[]}";
        #endregion

    }
}
