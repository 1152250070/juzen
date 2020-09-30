using Qiniu.Storage;
using Qiniu.Util;
using System.IO;

namespace Standard.Library.API
{
    public class QiniuUtil
    {
        public static string AccessKey = "3Z_sLXxSB8OQJml5nYgiei9kw76aiN3SImmKd62e";
        public static string SecretKey = "b6dw87piwph6f8XY7VHfcbCLmpHFV2KLPoeu-8bG";
      
        public static string Domain = "yukeqiniuupload.juzhentech.com";
       
        public static string Scope = "yuekeupload";
        /// <summary>
        /// 获取凭证
        /// </summary>
        /// <returns></returns>
        public static string GetUploadToken()
        {
            Mac mac = new Mac(AccessKey, SecretKey);
            PutPolicy putPolicy = new PutPolicy();
            //空间域
            putPolicy.Scope = Scope;
            //token的有效时间
            putPolicy.SetExpires(3600);
            //指定多少天自动删除
            //putPolicy.DeleteAfterDays = 1;
            return Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
        }
        public string ResumableUploader(Stream stream)
        {
            var token = GetUploadToken();
            Config config = new Config()
            {
                Zone = Zone.ZONE_CN_East,
                ChunkSize = ChunkUnit.U4096K,
                UseHttps = true,
                UseCdnDomains = true,
            };

            var uploader = new ResumableUploader(new Config() { });
            return null;//uploader.UploadFile(stream,"",token,null).Result.Text;
        }

    }
}
