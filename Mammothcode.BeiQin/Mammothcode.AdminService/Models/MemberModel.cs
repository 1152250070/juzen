using Mammothcode.Library.Data;
using Mammothcode.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mammothcode.AdminService.Models
{
    #region 教师PC管理
    public class SetMemOrderCourseModel : TokenModel
    {
        [Required]
        public int? CourseOrderId { get; set; }
        [Required]
        public int? ScheduleId { get; set; }
        [Required]
        public int? MId { get; set; }
        [Required]
        public int? MemOrderCourseId { get; set; }
        [Required]
        public int? OrderStatus { get; set; }

    }
    public class MemberLogoModel
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
    /// <summary>
    /// 教师课表
    /// </summary>
    public class GetTeacherScheduleModel : TokenPageModel
    {

        public int? ClassId { get; set; }
        /// <summary>
        /// 星期
        /// </summary>
        public int? WeekIndex { get; set; }
    }
    public class MemberToken
    {
        public int? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherMobile { get; set; }
        public DateTime ExpiryTime { get; set; }
        public static MemberToken GetToken(string token)
        {
            return token.FromBase64().FromJson<MemberToken>();
        }
        public string NewToken()
        {
            return this.ToJson().ToBase64();
        }
    }
    #endregion

    #region 用户管理
    public class GetMemCourseModel : TokenPageModel
    {

        public int? MId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrderDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CourseTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 课程包Id
        /// </summary>
        public int? CourseOrderId { get; set; }

        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public string ClassName { get; set; }
        public int? ClassId { get; set; }
        public int? ScheduleId { get; set; }


    }
    public class GetTeachClassModel : TokenPageModel
    {
        public string ClassName { get; set; }
    }

    #endregion

 
}
