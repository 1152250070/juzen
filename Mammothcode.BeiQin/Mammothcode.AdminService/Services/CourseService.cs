using Dapper.Linq;
using Mammothcode.AdminService.Models;
using Mammothcode.Model;
using Mammothcode.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mammothcode.AdminService.Services
{
    /// <summary>
    /// 课程管理
    /// </summary>
    public class CourseService : BaseService
    {
        #region 课程列表管理

        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult AddCourse(GoodCourseModel req)
        {
            var entity = req.NewInstance();
            entity.LookNum = 0;
            entity.ZanNum = 0;
            entity.CreateTime = DateTime.Now;
            var id = DbContext.From<GoodCourse>().InsertReturnId(entity);
            return Data(id);
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult UpdateCourse(GoodCourseModel req)
        {
            var entity = req.NewInstance();
            var row = DbContext.From<GoodCourse>()
                               .Update(entity);
            return IsOk(row > 0);
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult DeleteCourse(GoodCourseModel req)
        {
            var row = DbContext.From<GoodCourse>()
                               .Where(a => a.Id == req.Id)
                               .Delete();
            return IsOk(row > 0);
        }
        /// <summary>
        /// 获取课程列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult GetCourseList(GetCourseModel req)
        {
            var list = DbContext.From<GoodCourse>()
                                .Where(a => Operator.Contains(a.CourseName, req.CourseName), !string.IsNullOrEmpty(req.CourseName))
                                .Where(a => a.Status == req.Status, req.Status != null)
                                .OrderByDescending(a => a.Id)
                                .Page(req, out long total)
                                .Select();
            return Data(list, total);
        }
        #endregion

        #region 课程相关处理
        /// <summary>
        ///获取课程评论
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult GetCourseCommentList(CourseCommentModel req)
        {
            var data = DbContext.From<CourseComment, GoodCourse>()
                                 .Join((a, b) => a.CourseId == b.Id)
                                 .Where((a, b) => a.CourseId == req.CourseId, req.CourseId != null)
                                 .Where((a, b) => a.MId == req.MId, req.MId != null)
                                 .Where((a, b) => Operator.Contains(a.NickName, req.NickName), !string.IsNullOrEmpty(req.NickName))
                                 .OrderByDescending((a, b) => a.Id)
                                 .Page(req, out long total)
                                 .Select((a, b) => new
                                 {
                                     a.NickName,
                                     a.RealName,
                                     a.HeadImg,
                                     a.CContent,
                                     a.CreateTime,
                                     b.CourseImg,
                                     b.CourseName,
                                 });
            return Data(data, total);
        }
        /// <summary>
        ///获取课程点赞
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult GetCourseZanList(CourseCommentModel req)
        {
            var data = DbContext.From<CourseZan, GoodCourse>()
                                .Join((a, b) => a.CourseId == b.Id)
                                .Where((a, b) => a.CourseId == req.CourseId, req.CourseId != null)
                                .Where((a, b) => a.MId == req.MId, req.MId != null)
                                .Where((a, b) => Operator.Contains(a.NickName, req.NickName), !string.IsNullOrEmpty(req.NickName))
                                .OrderByDescending((a, b) => a.Id)
                                .Page(req, out long total)
                                .Select((a, b) => new
                                {
                                    a.NickName,
                                    a.RealName,
                                    a.HeadImg,
                                    a.CreateTime,
                                    b.CourseImg,
                                    b.CourseName,
                                });
            return Data(data, total);
        }
        #endregion

    }
}
