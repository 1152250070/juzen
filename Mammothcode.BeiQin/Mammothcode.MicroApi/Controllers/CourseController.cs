using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mammothcode.MicroService.Models;
using Mammothcode.MicroService.Services;
using Mammothcode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mammothcode.MicroApi.Controllers
{
    /// <summary>
    /// 课程管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        CourseService Service = ServiceFactory.GetService<CourseService>();

        #region 用户观看记录
        ///<summary>
        ///获取课程列表
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetCourseList(GetCourseModel req)
        {
            var data = Service.GetCourseList(req);
            return Ok(data);
        }
        ///<summary>
        ///获取课程详情
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetCourseDetails(GetCourseDetailsModel req)
        {
            var data = Service.GetCourseDetails(req);
            return Ok(data);
        }
        ///<summary>
        ///获取课程评论
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetCourseCommentList(GetCourseCommentModel req)
        {
            var data = Service.GetCourseCommentList(req);
            return Ok(data);
        }
        #endregion

        #region 点赞相关管理

        #region 课程点赞
        ///<summary>
        ///课程点赞
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult MemCourseZan(MemCourseZanModel req)
        {
            var data = Service.MemCourseZan(req);
            return Ok(data);
        }
        ///<summary>
        ///取消课程点赞
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult CanceMemCourseZan(MemCourseZanModel req)
        {
            var data = Service.CanceMemCourseZan(req);
            return Ok(data);
        }
        #endregion

        #region 评论点赞
        ///<summary>
        ///评论点赞
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult MemCommentZan(MemCommentZanModel req)
        {
            var data = Service.MemCommentZan(req);
            return Ok(data);
        }
        ///<summary>
        ///取消评论点赞
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult CanceMemCommentZan(MemCommentZanModel req)
        {
            var data = Service.CanceMemCommentZan(req);
            return Ok(data);
        }
        #endregion

        #endregion

    }
}