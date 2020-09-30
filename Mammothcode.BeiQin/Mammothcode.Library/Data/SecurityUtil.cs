using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mammothcode.Library.Data
{
    /// <summary>
    /// 加密解密、MD5
    /// </summary>
    public class SecurityUtil
    {
        #region Md5 32bit 64bit 加密
        /// <summary>
        /// M516位加密
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="lower">是否小写</param>
        /// <returns></returns>
        public static string Md5_16BitHash(string text, bool lower=true)
        {
            using (var cryp = MD5.Create())
            {
                var data = cryp.ComputeHash(Encoding.UTF8.GetBytes(text));
                var crypdata = string.Join("", data.Select(s => s.ToString(lower ? "x2" : "X2"))).Substring(8, 16);
                return crypdata;
            }
           
        }
        /// <summary>
        /// M532位加密
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="lower">是否小写</param>
        /// <returns></returns>
        public static string Md5_32BitHash(string text, bool lower=true)
        {
            using (var cryp = MD5.Create())
            {
                var data = cryp.ComputeHash(Encoding.UTF8.GetBytes(text));
                var crypdata = string.Join("", data.Select(s => s.ToString(lower ? "x2" : "X2")));
                return crypdata;
            }
        }
        #endregion

        #region AES-128-CBC PKCS#7 加密/解密

        /// <summary>
        /// AES-128-CBC 加密
        /// 王剑锋 2018年7月7日09:58:34
        /// </summary>
        /// <param name="text">base64明文</param>
        /// <param name="key">base64秘钥</param>
        /// <param name="iv">base64向量</param>
        /// <returns></returns>
        public static string AesEncryp(string text, string key, string iv)
        {
            using (var aes = Aes.Create())
            {
                //AES-128-CBC PKCS#7
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;
                aes.BlockSize = 128;
                //Base64解密text,KEY,IV,不够16位填充0
                aes.Key = FillToEnd(Convert.FromBase64String(key), 16, 0);
                aes.IV = FillToEnd(Convert.FromBase64String(iv), 16, 0);
                //获取该算法规则下的加密器
                var encryp = aes.CreateEncryptor();
                //加密之前加一个Base64解密 ,要加密的数据
                var data = Convert.FromBase64String(text);
                //获取AES-128-CBC PKCS#7 密文
                return Convert.ToBase64String(encryp.TransformFinalBlock(data, 0, data.Length));
            }
        }

        /// <summary>
        /// AES-128-CBC 解密
        /// 王剑锋 2018年7月7日09:58:16
        /// </summary>
        /// <param name="text">密文</param>
        /// <param name="key">base64秘钥,Base64串</param>
        /// <param name="iv">base64向量</param>
        /// <returns></returns>
        public static string AesDecryp(string text, string key, string iv)
        {
            using (var aes = Aes.Create())
            {
                //AES-128-CBC PKCS#7
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;
                aes.BlockSize = 128;
                //Base64解密text,KEY,IV
                aes.Key = FillToEnd(Convert.FromBase64String(key), 16, 0);
                aes.IV = FillToEnd(Convert.FromBase64String(iv), 16, 0);
                //获取该算法规则下的解密器
                var encryp = aes.CreateDecryptor();
                //加密之前加一个Base64解密 ,要加密的数据
                var data = Convert.FromBase64String(text);
                //获取AES-128-CBC PKCS#7 明文
                return Encoding.UTF8.GetString(encryp.TransformFinalBlock(data, 0, data.Length));
            }          
        }

        #endregion

        #region 填充算法
        /// <summary>
        /// 末位填充
        /// </summary>
        /// <param name="bytes">源</param>
        /// <param name="size">倍数</param>
        /// <param name="data">填充数</param>
        /// <returns></returns>
        public static byte[] FillToEnd(byte[] bytes, int size, byte data)
        {
            int group = (bytes.Length + size - 1) / size;
            var list = new byte[group * size];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = i < bytes.Length ? bytes[i] : data;
            }
            return list;
        }
        /// <summary>
        /// 首位填充
        /// </summary>
        /// <param name="bytes">源</param>
        /// <param name="size">倍数</param>
        /// <param name="data">填充数</param>
        /// <returns></returns>
        public static byte[] FillToStart(byte[] bytes, byte data)
        {
            int group = (bytes.Length + 15) / 16;
            var list = new byte[group * 16];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = i < bytes.Length ? bytes[i] : data;
            }
            return list;
        }
        #endregion
    }
}
