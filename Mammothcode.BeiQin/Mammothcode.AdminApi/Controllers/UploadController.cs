using Mammothcode.Library.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Mammothcode.AdminApi.Controllers
{
    /// <summary>
    /// 图片上传控制器
    /// </summary>
    [Route("api/upload/file")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        #region 上传统一接口
        [HttpPost]
        public JsonResult Upload([FromForm]UploadModel req)
        {
            //文件所在服务器路径
            #region 非空验证
            if (string.IsNullOrEmpty(req.Path))
            {
                return new JsonResult(new
                {
                    Result = false,
                    Message = "path不能为空"
                });
            }
            #endregion

            #region 保存路径，如果不存在则创建
            var savepath = string.Format("{0}\\wwwroot\\{1}\\{2}", Environment.CurrentDirectory, req.Path, DateTime.Now.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }
            #endregion

            #region 请求分发
            if (req.File.ContentType.Contains("image"))
            {
                var uri = UpoladImage(req);
                return new JsonResult(new
                {
                    Result = true,
                    Message = "success",
                    Data = uri
                });
            }
            else if (req.File.ContentType.Contains("video/mp4"))
            {
                var uri = UpoladVideo(req);
                return new JsonResult(new
                {
                    Result = true,
                    Message = "success",
                    Data = uri
                });
            }

            #endregion

            return new JsonResult(new
            {
                Result = false,
                Message = "不支持的文件类型"

            });
        }
        #endregion

        #region 上传图片
        private string UpoladImage(UploadModel req)
        {
            var savepath = string.Format("{0}\\wwwroot\\{1}\\{2}", Environment.CurrentDirectory, req.Path, DateTime.Now.ToString("yyyy-MM-dd"));
            //文件信息
            var file = req.File;
            var filename = Guid.NewGuid().ToString("N");
            var extension = Path.GetExtension(file.FileName);
            var imagepath = string.Format("{0}\\{1}{2}", savepath, filename, extension);
            using (var stream = file.OpenReadStream())
            {
                using (var fs = new FileStream(imagepath, FileMode.CreateNew))
                {
                    stream.CopyTo(fs);
                }
            }
            return string.Format("{0}{1}{2}", string.Format("/{0}/{1}/", req.Path, DateTime.Now.ToString("yyyy-MM-dd")), filename, extension);
        }
        #endregion

        #region 上传视频
        private string UpoladVideo(UploadModel req)
        {
            var savepath = string.Format("{0}\\wwwroot\\{1}\\{2}", Environment.CurrentDirectory, req.Path, DateTime.Now.ToString("yyyy-MM-dd"));
            //文件信息
            var file = req.File;
            var filename = Guid.NewGuid().ToString("N");
            var extension = Path.GetExtension(file.FileName);
            var videopath = string.Format("{0}\\{1}{2}", savepath, filename, extension);
            using (var stream = file.OpenReadStream())
            {
                using (var fs = new FileStream(videopath, FileMode.CreateNew))
                {
                    stream.CopyTo(fs);
                }
            }
            return string.Format("{0}{1}{2}", string.Format("/{0}/{1}/", req.Path, DateTime.Now.ToString("yyyy-MM-dd")), filename, extension);
        }
        #endregion

    }

    /// <summary>
    /// 上传文件请求参数
    /// </summary>
    public class UploadModel
    {
        public string Path { get; set; }
        public IFormFile File { get; set; }
    }

}