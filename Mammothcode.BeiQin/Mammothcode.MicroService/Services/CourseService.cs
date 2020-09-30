using Mammothcode.MicroService.Models;
using Mammothcode.Model;
using Mammothcode.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mammothcode.MicroService.Services
{
    /// <summary>
    /// 课程管理
    /// </summary>
    public class CourseService : BaseService
    {
        #region 课程管理
        /// <summary>
        /// 获取课程列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetCourseList(GetCourseModel req)
        {

            var list = DbContext.From<GoodCourse>()
                                .Where(a => a.IsHot == req.IsHot, req.IsHot != null)
                                .Where(a => a.IsNew == req.IsNew, req.IsNew != null)
                                .OrderByDescending(a => a.Id)
                                .Page(req, out long total)
                                .Select();
            return Data(list, total);
        }
        /// <summary>
        /// 获取课程详情
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetCourseDetails(GetCourseDetailsModel req)
        {

            var data = DbContext.From<GoodCourse>()
                                .Where(a => a.Id == req.Id)
                                .Single();
            return Data(data);
        }
        /// <summary>
        /// 获取课程评论
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetCourseCommentList(GetCourseCommentModel req)
        {

            var data = DbContext.From<CourseComment>()
                                .Where(a => a.CourseId == req.Id)
                                .OrderByDescending(a => a.Id)
                                .Page(req, out long total)
                                .Select();
            //获取评论点赞
            var commentZan = DbContext.From<CommentZan>().Select();
            var list = data.Select(a => new
            {
                a.CContent,
                a.CourseId,
                a.CreateTime,
                a.HeadImg,
                a.Id,
                a.MId,
                a.NickName,
                a.RealName,
                a.ZanNum,
                IsZan = commentZan.Where(b => b.Id == a.Id).FirstOrDefault() == null ? false : true,
            });
            return Data(list, total);
        }
        #endregion

        #region 点赞相关管理

        #region 课程点赞
        /// <summary>
        /// 课程点赞
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult MemCourseZan(MemCourseZanModel req)
        {
            //获取用户信息
            var memInfm = DbContext.From<Member>().Where(a => a.Id == req.MId).Single();
            var data = DbContext.From<CourseZan>().InsertReturnId(new CourseZan()
            {
                CourseId = req.CourseId,
                MId = memInfm.Id,
                HeadImg = memInfm.HeadImg,
                NickName = memInfm.NickName,
                RealName = memInfm.RealName,
                CreateTime = DateTime.Now,
            });
            //增加课程点赞
            var row = DbContext.From<GoodCourse>()
                               .Set(a => a.ZanNum, a => a.ZanNum + 1)
                               .Where(a => a.Id == req.CourseId)
                               .Update();
            return Data(data);
        }
        /// <summary>
        /// 取消课程点赞
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult CanceMemCourseZan(MemCourseZanModel req)
        {
            //获取用户信息
            var row = DbContext.From<CourseZan>()
                                   .Where(a => a.CourseId == req.CourseId)
                                   .Where(a => a.MId == req.MId)
                                   .Delete();
            //增加课程点赞
            var row2 = DbContext.From<GoodCourse>()
                               .Set(a => a.ZanNum, a => a.ZanNum -1)
                               .Where(a => a.Id == req.CourseId)
                               .Update();

            return Data(row > 0);
        }
        #endregion

        #region 评论点赞
        /// <summary>
        /// 评论点赞
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult MemCommentZan(MemCommentZanModel req)
        {
            //获取用户信息
            var memInfm = DbContext.From<Member>().Where(a => a.Id == req.MId).Single();
            var data = DbContext.From<CommentZan>().InsertReturnId(new CommentZan()
            {
                CommentId = req.CommentId,
                MId = memInfm.Id,
                HeadImg = memInfm.HeadImg,
                NickName = memInfm.NickName,
                RealName = memInfm.RealName,
                CreateTime = DateTime.Now,
            });
            return Data(data);
        }
        /// <summary>
        /// 取消评论点赞
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult CanceMemCommentZan(MemCommentZanModel req)
        {

            var row = DbContext.From<CommentZan>()
                                   .Where(a => a.CommentId == req.CommentId)
                                   .Where(a => a.MId == req.MId)
                                   .Delete();

            return Data(row > 0);
        }
        #endregion

        #endregion
    }
}
