using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mammothcode.AdminService.Models;
using Mammothcode.AdminService.Services;
using Mammothcode.Model;
using Mammothcode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mammothcode.AdminApi.Controllers
{
    /// <summary>
    /// 课程管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        CourseService Service = ServiceFactory.GetService<CourseService>();


        #region  课程列表管理
        ///<summary>
        ///新增课程
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult AddCourse(GoodCourseModel req)
        {
            var data = Service.AddCourse(req);
            return Ok(data);
        }
        ///<summary>
        ///修改课程
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult UpdateCourseBase(GoodCourseModel req)
        {
            var data = Service.UpdateCourse(req);
            return Ok(data);
        }
        ///<summary>
        ///删除课程
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult DeleteCourseBase(GoodCourseModel req)
        {
            var data = Service.DeleteCourse(req);
            return Ok(data);
        }
        ///<summary>
        ///获取课程列表
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetCourseBaseList(GetCourseModel req)
        {
            var data = Service.GetCourseList(req);
            return Ok(data);
        }
        #endregion

        ///<summary>
        ///获取课程评论
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetCourseCommentList(CourseCommentModel req)
        {
            var data = Service.GetCourseCommentList(req);
            return Ok(data);
        }
        ///<summary>
        ///获取课程点赞
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetCourseZanList(CourseCommentModel req)
        {
            var data = Service.GetCourseZanList(req);
            return Ok(data);
        }

    }
}