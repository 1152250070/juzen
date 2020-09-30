
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mammothcode.Wechat
{
    public static class StringUtil
    {

        #region timestamp
        /// <summary>
        /// 转换成时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        #region rand string
        public static string GetNonceStr()
        {
            return Guid.NewGuid().ToString("N");
        }
        #endregion

        #region SHA1加密
        public static string GetSHA1(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var sha1 = SHA1.Create())
            {
                bytes = sha1.ComputeHash(bytes);
                return string.Join("", bytes.Select(s => s.ToString("X2")));
            }
        }
        #endregion

        #region MD5加密
        public static string GetMD532Bit(string text, string format = "X2")
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var md5 = MD5.Create())
            {
                bytes = md5.ComputeHash(bytes);
                return string.Join("", bytes.Select(s => s.ToString(format)));
            }
           
        }
        #endregion

        #region SHA256加密
        public static string GetSHA256(string text, string format = "X2")
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(Wechat_Config.Key)))
            {
                var bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
                return string.Join("", bytes.Select(s => s.ToString(format)));
            }
        }
        #endregion

        #region CBC\PKCS7
        public static string CBCPKCS7Hash(string text, string key, string iv)
        {
            var data = Convert.FromBase64String(text);
            using (var aes = new RijndaelManaged())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var er = aes.CreateDecryptor();
                var encry = er.TransformFinalBlock(data, 0, data.Length);
                var enstr = Encoding.UTF8.GetString(encry);
                return enstr;
            }
           
        }
        #endregion

        #region AES-128-CBC PKCS#7 解密
        public static string Aes128CBCDecryp(string text, string key, string iv)
        {
            using (var aes = Aes.Create())
            {
                //AES-128-CBC PKCS#7
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;
                aes.BlockSize = 128;
                //Base64解密text,KEY,IV
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                //获取该算法规则下的解密器
                var encryp = aes.CreateDecryptor();
                //加密之前加一个Base64解密 ,要加密的数据
                var data = Convert.FromBase64String(text);
                //获取AES-128-CBC PKCS#7 明文
                return System.Text.Encoding.UTF8.GetString(encryp.TransformFinalBlock(data, 0, data.Length));
            }
        }
        #endregion
    }
}
