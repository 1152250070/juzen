using Mammothcode.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mammothcode.MicroService.Models
{
    /// <summary>
    /// 获取课程类别
    /// </summary>
    public class GetCourseModel : PageModel
    {
        public bool? IsNew { get; set; }
        public bool? IsHot { get; set; }
    }
    /// <summary>
    /// 获取课详情
    /// </summary>
    public class GetCourseDetailsModel 
    {
        [Required]
        public int Id { get; set; }
        public int? MId { get; set; }
    }
    /// <summary>
    /// 获取课程评论
    /// </summary>
    public class GetCourseCommentModel:PageModel
    {
        [Required]
        public int Id { get; set; }
        public int? MId { get; set; }
    }
    /// <summary>
    /// 课程点赞
    /// </summary>
    public class MemCourseZanModel 
    {
        [Required]
        public int? MId { get; set; }
        [Required]
        public int? CourseId { get; set; }
    }
    /// <summary>
    /// 评论点赞
    /// </summary>
    public class MemCommentZanModel
    {
        [Required]
        public int? MId { get; set; }
        [Required]
        public int? CommentId { get; set; }
    }

}
