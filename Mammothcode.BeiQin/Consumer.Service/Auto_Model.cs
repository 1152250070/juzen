

using System;
using Dapper.Linq;

namespace Mammothcode.Model
{
    /// <summary>
    /// 预约课状态
    /// </summary>
    public enum OrderStatusEnum
    {
        未签到 = -3,
        请假 = -2,
        取消 = -1,
        排队中 = 0,
        待上课 = 1,
        已记课 = 2
    }
    /// <summary>
    /// 客户预约的课程表
	/// 更新时间：2020-07-29 17:51:15
    /// </summary>
	[Table("`member_order_course`")]
    public partial class MemberOrderCourse
    {

        /// <summary>
        /// 
        /// ColumnType：int(11), IsNull：NO, Default：NULL
        /// </summary>
        [Column("`id`", ColumnKey.Primary, true)]
        public int? Id { get; set; }

        /// <summary>
        /// 课表Id
        /// ColumnType：int(11), IsNull：NO, Default：NULL
        /// </summary>
        [Column("`schedule_id`", ColumnKey.None, false)]
        public int? ScheduleId { get; set; }

        /// <summary>
        /// 课程订单Id
        /// ColumnType：int(10), IsNull：NO, Default：NULL
        /// </summary>
        [Column("`course_order_id`", ColumnKey.None, false)]
        public int? CourseOrderId { get; set; }

        /// <summary>
        /// 预约状态
        /// ColumnType：int(11), IsNull：NO, Default：NULL
        /// </summary>
        [Column("`order_status`", ColumnKey.None, false)]
        public int? OrderStatus { get; set; }

        /// <summary>
        /// 用户Id
        /// ColumnType：int(10), IsNull：NO, Default：NULL
        /// </summary>
        [Column("`m_id`", ColumnKey.None, false)]
        public int? MId { get; set; }

        /// <summary>
        /// 约课日期
        /// ColumnType：datetime, IsNull：YES, Default：NULL
        /// </summary>
        [Column("`order_date`", ColumnKey.None, false)]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// 上课开始时间
        /// ColumnType：datetime, IsNull：YES, Default：NULL
        /// </summary>
        [Column("`order_start_time`", ColumnKey.None, false)]
        public DateTime? OrderStartTime { get; set; }

        /// <summary>
        /// 上课结束时间
        /// ColumnType：datetime, IsNull：YES, Default：NULL
        /// </summary>
        [Column("`order_end_time`", ColumnKey.None, false)]
        public DateTime? OrderEndTime { get; set; }

        /// <summary>
        /// 备注
        /// ColumnType：varchar(500), IsNull：YES, Default：NULL
        /// </summary>
        [Column("`remark`", ColumnKey.None, false)]
        public string Remark { get; set; }

        /// <summary>
        /// 完成时间
        /// ColumnType：datetime, IsNull：YES, Default：NULL
        /// </summary>
        [Column("`finish_time`", ColumnKey.None, false)]
        public DateTime? FinishTime { get; set; }

        /// <summary>
        /// 使用课时
        /// ColumnType：decimal(6,2), IsNull：YES, Default：NULL
        /// </summary>
        [Column("`use_class_time`", ColumnKey.None, false)]
        public decimal? UseClassTime { get; set; }

        /// <summary>
        /// 剩余课时
        /// ColumnType：decimal(6,2), IsNull：YES, Default：NULL
        /// </summary>
        [Column("`remaining_class_time`", ColumnKey.None, false)]
        public decimal? RemainingClassTime { get; set; }

        /// <summary>
        /// 
        /// ColumnType：varchar(255), IsNull：YES, Default：NULL
        /// </summary>
        [Column("`nick_name`", ColumnKey.None, false)]
        public string NickName { get; set; }

        /// <summary>
        /// 
        /// ColumnType：varchar(255), IsNull：YES, Default：NULL
        /// </summary>
        [Column("`real_name`", ColumnKey.None, false)]
        public string RealName { get; set; }

        /// <summary>
        /// 
        /// ColumnType：varchar(36), IsNull：YES, Default：NULL
        /// </summary>
        [Column("`mobile`", ColumnKey.None, false)]
        public string Mobile { get; set; }

        /// <summary>
        /// 
        /// ColumnType：datetime, IsNull：YES, Default：NULL
        /// </summary>
        [Column("`create_time`", ColumnKey.None, false)]
        public DateTime? CreateTime { get; set; }
    }

    /// <summary>
    /// 基础班级表
    /// 更新时间：2020-06-30 17:14:11
    /// </summary>
    [Table("`class_base`")]
	public partial class ClassBase
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 班级名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`class_name`", ColumnKey.None, false)]
		public string ClassName { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`sort`", ColumnKey.None, false)]
		public int? Sort { get; set; }
	}
	
	/// <summary>
    /// 基础课程表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`course_base`")]
	public partial class CourseBase
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_type_id`", ColumnKey.None, false)]
		public int? CourseTypeId { get; set; }
			
		/// <summary>
		/// 课程名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_name`", ColumnKey.None, false)]
		public string CourseName { get; set; }
			
		/// <summary>
		/// 课时
		/// ColumnType：decimal(6,2), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_time`", ColumnKey.None, false)]
		public decimal? CourseTime { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 课程包表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`course_order`")]
	public partial class CourseOrder
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 0=通用课包，1=指定课包
		/// ColumnType：int(2), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`order_type`", ColumnKey.None, false)]
		public int? OrderType { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
		/// <summary>
		/// 用户电话
		/// ColumnType：varchar(36), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`m_mobile`", ColumnKey.None, false)]
		public string MMobile { get; set; }
			
		/// <summary>
		/// 用户姓名
		/// ColumnType：varchar(255), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`real_name`", ColumnKey.None, false)]
		public string RealName { get; set; }
			
		/// <summary>
		/// 学生ID
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`student_id`", ColumnKey.None, false)]
		public int? StudentId { get; set; }
			
		/// <summary>
		/// 学生名字
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`student_name`", ColumnKey.None, false)]
		public string StudentName { get; set; }
			
		/// <summary>
		/// 支付金额
		/// ColumnType：decimal(10,2), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`pay_fee`", ColumnKey.None, false)]
		public decimal? PayFee { get; set; }
			
		/// <summary>
		/// 完成次数
		/// ColumnType：int(11), IsNull：YES, Default：0
		/// </summary>
		[Column("`finish_num`", ColumnKey.None, false)]
		public int? FinishNum { get; set; }
			
		/// <summary>
		/// 没有完成次数
		/// ColumnType：int(11), IsNull：YES, Default：0
		/// </summary>
		[Column("`no_finish_num`", ColumnKey.None, false)]
		public int? NoFinishNum { get; set; }
			
		/// <summary>
		/// 可以请假的次数
		/// ColumnType：int(10), IsNull：YES, Default：0
		/// </summary>
		[Column("`total_leave_num`", ColumnKey.None, false)]
		public int? TotalLeaveNum { get; set; }
			
		/// <summary>
		/// 已经请假次数
		/// ColumnType：int(11), IsNull：YES, Default：0
		/// </summary>
		[Column("`leave_num`", ColumnKey.None, false)]
		public int? LeaveNum { get; set; }
			
		/// <summary>
		/// 有效时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`effective_tiem`", ColumnKey.None, false)]
		public DateTime? EffectiveTiem { get; set; }
			
		/// <summary>
		/// 附件地址
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`attach_url`", ColumnKey.None, false)]
		public string AttachUrl { get; set; }
			
		/// <summary>
		/// 创建时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
			
		/// <summary>
		/// 总课时
		/// ColumnType：decimal(6,2), IsNull：YES, Default：0.00
		/// </summary>
		[Column("`total_class_time`", ColumnKey.None, false)]
		public decimal? TotalClassTime { get; set; }
			
		/// <summary>
		/// 剩余课时
		/// ColumnType：decimal(6,2), IsNull：YES, Default：0.00
		/// </summary>
		[Column("`remaining_class_time`", ColumnKey.None, false)]
		public decimal? RemainingClassTime { get; set; }
	}
	
	/// <summary>
    /// 课程包_跟随的课程
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`course_order_item`")]
	public partial class CourseOrderItem
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 课程包Id
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`course_order_id`", ColumnKey.None, false)]
		public int? CourseOrderId { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
		/// <summary>
		/// 课程Id
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`course_id`", ColumnKey.None, false)]
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 课程name
		/// ColumnType：varchar(255), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`course_name`", ColumnKey.None, false)]
		public string CourseName { get; set; }
			
		/// <summary>
		/// 创建时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 课程类型
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`course_type`")]
	public partial class CourseType
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(100), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`type_name`", ColumnKey.None, false)]
		public string TypeName { get; set; }
			
		/// <summary>
		/// 排序
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`sort`", ColumnKey.None, false)]
		public int? Sort { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 用户表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`member`")]
	public partial class Member
	{
				
		/// <summary>
		/// 编号
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 用户手机号码
		/// ColumnType：varchar(36), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`mobile`", ColumnKey.None, false)]
		public string Mobile { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`open_id`", ColumnKey.None, false)]
		public string OpenId { get; set; }
			
		/// <summary>
		/// 微信头像
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`head_img`", ColumnKey.None, false)]
		public string HeadImg { get; set; }
			
		/// <summary>
		/// 昵称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`nick_name`", ColumnKey.None, false)]
		public string NickName { get; set; }
			
		/// <summary>
		/// 用户姓名
		/// ColumnType：varchar(255), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`real_name`", ColumnKey.None, false)]
		public string RealName { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`stu_name`", ColumnKey.None, false)]
		public string StuName { get; set; }
			
		/// <summary>
		/// 学生生日
		/// ColumnType：varchar(100), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`stu_birthday`", ColumnKey.None, false)]
		public string StuBirthday { get; set; }
			
		/// <summary>
		/// 学生头像
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`stu_img`", ColumnKey.None, false)]
		public string StuImg { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 用户消息表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`member_message`")]
	public partial class MemberMessage
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 用户ID
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
		/// <summary>
		/// 标题
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`title`", ColumnKey.None, false)]
		public string Title { get; set; }
			
		/// <summary>
		/// 内容
		/// ColumnType：varchar(4000), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`message_text`", ColumnKey.None, false)]
		public string MessageText { get; set; }
			
		/// <summary>
		/// 跳转类型 0=文本，1=链接
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`target_type`", ColumnKey.None, false)]
		public int? TargetType { get; set; }
			
		/// <summary>
		/// 链接地址
		/// ColumnType：varchar(100), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`target_url`", ColumnKey.None, false)]
		public string TargetUrl { get; set; }
			
		/// <summary>
		/// 是否已读 false=未读，true=已读
		/// ColumnType：bit(1), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`is_read`", ColumnKey.None, false)]
		public bool? IsRead { get; set; }
			
		/// <summary>
		/// 创建时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	
	/// <summary>
    /// 基础课程表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`schedule_base`")]
	public partial class ScheduleBase
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 班级名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`class_name`", ColumnKey.None, false)]
		public string ClassName { get; set; }
			
		/// <summary>
		/// 课程类别Id
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_type_id`", ColumnKey.None, false)]
		public int? CourseTypeId { get; set; }
			
		/// <summary>
		/// 课程Id
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_id`", ColumnKey.None, false)]
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 课程名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_name`", ColumnKey.None, false)]
		public string CourseName { get; set; }
			
		/// <summary>
		/// 教师Id
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`teacher_id`", ColumnKey.None, false)]
		public int? TeacherId { get; set; }
			
		/// <summary>
		/// 教师姓名
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`teacher_name`", ColumnKey.None, false)]
		public string TeacherName { get; set; }
			
		/// <summary>
		/// 预约日期
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`order_date`", ColumnKey.None, false)]
		public DateTime? OrderDate { get; set; }
			
		/// <summary>
		/// 预约时间段
		/// ColumnType：varchar(100), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`order_time`", ColumnKey.None, false)]
		public string OrderTime { get; set; }
			
		/// <summary>
		/// 可以报名人数
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`total_sign_up`", ColumnKey.None, false)]
		public int? TotalSignUp { get; set; }
			
		/// <summary>
		/// 已报名人数
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`sign_up_num`", ColumnKey.None, false)]
		public int? SignUpNum { get; set; }
			
		/// <summary>
		/// 排队人数
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`line_up_num`", ColumnKey.None, false)]
		public int? LineUpNum { get; set; }
			
		/// <summary>
		/// 请假人数
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`leave_num`", ColumnKey.None, false)]
		public int? LeaveNum { get; set; }
			
		/// <summary>
		/// 课时
		/// ColumnType：decimal(6,2), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_time`", ColumnKey.None, false)]
		public decimal? CourseTime { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`sort`", ColumnKey.None, false)]
		public int? Sort { get; set; }
			
		/// <summary>
		/// 创建时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 学生请假表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`student_leave`")]
	public partial class StudentLeave
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`student_id`", ColumnKey.None, false)]
		public int? StudentId { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`student_name`", ColumnKey.None, false)]
		public string StudentName { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
		/// <summary>
		/// 家长姓名
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`parents_name`", ColumnKey.None, false)]
		public string ParentsName { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`nick`", ColumnKey.None, false)]
		public string Nick { get; set; }
			
		/// <summary>
		/// 用户预约时间Id
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`m_order_c_id`", ColumnKey.None, false)]
		public int? MOrderCId { get; set; }
			
		/// <summary>
		/// 请假原因
		/// ColumnType：varchar(500), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`remark`", ColumnKey.None, false)]
		public string Remark { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 学生基础信息表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`students_base`")]
	public partial class StudentsBase
	{
				
		/// <summary>
		/// 编号
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`stu_name`", ColumnKey.None, false)]
		public string StuName { get; set; }
			
		/// <summary>
		/// 学生生日
		/// ColumnType：varchar(100), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`stu_birthday`", ColumnKey.None, false)]
		public string StuBirthday { get; set; }
			
		/// <summary>
		/// 学生头像
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`stu_img`", ColumnKey.None, false)]
		public string StuImg { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`sort`", ColumnKey.None, false)]
		public int? Sort { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 系统管理员
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`system_admin`")]
	public partial class SystemAdmin
	{
				
		/// <summary>
		/// ID
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`ID`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 后台用户CODE
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`AU_CODE`", ColumnKey.None, false)]
		public string AuCode { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`RO_CODE`", ColumnKey.None, false)]
		public string RoCode { get; set; }
			
		/// <summary>
		/// 后台用户名称
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`AU_NAME`", ColumnKey.None, false)]
		public string AuName { get; set; }
			
		/// <summary>
		/// 描述
		/// ColumnType：text, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`AU_DESC`", ColumnKey.None, false)]
		public string AuDesc { get; set; }
			
		/// <summary>
		/// 管理员账号
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`ACCOUNT`", ColumnKey.None, false)]
		public string Account { get; set; }
			
		/// <summary>
		/// 职务
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`AU_POST`", ColumnKey.None, false)]
		public string AuPost { get; set; }
			
		/// <summary>
		/// 手机号
		/// ColumnType：varchar(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`AU_MOBILE`", ColumnKey.None, false)]
		public string AuMobile { get; set; }
			
		/// <summary>
		/// 性别
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`AU_SEX`", ColumnKey.None, false)]
		public int? AuSex { get; set; }
			
		/// <summary>
		/// -1超级管理员是否超级管理
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`AU_POWER`", ColumnKey.None, false)]
		public int? AuPower { get; set; }
			
		/// <summary>
		/// 密码
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`PASSWORD`", ColumnKey.None, false)]
		public string Password { get; set; }
			
		/// <summary>
		/// 创建时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`CREATE_TIME`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 公司基础信息配置表
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`system_config`")]
	public partial class SystemConfig
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 省名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`p_name`", ColumnKey.None, false)]
		public string PName { get; set; }
			
		/// <summary>
		/// 市名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`c_name`", ColumnKey.None, false)]
		public string CName { get; set; }
			
		/// <summary>
		/// 区名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`a_name`", ColumnKey.None, false)]
		public string AName { get; set; }
			
		/// <summary>
		/// 省编号
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`p_id`", ColumnKey.None, false)]
		public string PId { get; set; }
			
		/// <summary>
		/// 市编号
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`c_id`", ColumnKey.None, false)]
		public string CId { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`a_id`", ColumnKey.None, false)]
		public string AId { get; set; }
			
		/// <summary>
		/// 省市区地址
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`address`", ColumnKey.None, false)]
		public string Address { get; set; }
			
		/// <summary>
		/// 详细地址
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`address_detail`", ColumnKey.None, false)]
		public string AddressDetail { get; set; }
			
		/// <summary>
		/// 经度
		/// ColumnType：double(11,6), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`longitude`", ColumnKey.None, false)]
		public double? Longitude { get; set; }
			
		/// <summary>
		/// 纬度
		/// ColumnType：double(11,6), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`latitude`", ColumnKey.None, false)]
		public double? Latitude { get; set; }
			
		/// <summary>
		/// 公司电话
		/// ColumnType：varchar(36), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`company_mobile`", ColumnKey.None, false)]
		public string CompanyMobile { get; set; }
			
		/// <summary>
		/// 其他电话
		/// ColumnType：varchar(36), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`other_mobile`", ColumnKey.None, false)]
		public string OtherMobile { get; set; }
			
		/// <summary>
		/// 公司名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`company_name`", ColumnKey.None, false)]
		public string CompanyName { get; set; }
	}
	
	/// <summary>
    /// 系统菜单
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`system_menus`")]
	public partial class SystemMenus
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`ID`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 菜单CODE
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`MU_CODE`", ColumnKey.None, false)]
		public string MuCode { get; set; }
			
		/// <summary>
		/// 父节点菜单
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`PMU_CODE`", ColumnKey.None, false)]
		public string PmuCode { get; set; }
			
		/// <summary>
		/// 菜单名称
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`MU_NAME`", ColumnKey.None, false)]
		public string MuName { get; set; }
			
		/// <summary>
		/// 0内容，1系统
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`MU_TYPE`", ColumnKey.None, false)]
		public int? MuType { get; set; }
			
		/// <summary>
		/// 是否子节点
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`IS_CHILD`", ColumnKey.None, false)]
		public int? IsChild { get; set; }
			
		/// <summary>
		/// 跳转链接
		/// ColumnType：varchar(225), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`MU_URL`", ColumnKey.None, false)]
		public string MuUrl { get; set; }
			
		/// <summary>
		/// 图标
		/// ColumnType：varchar(225), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`MU_ICON`", ColumnKey.None, false)]
		public string MuIcon { get; set; }
			
		/// <summary>
		/// 功能描述
		/// ColumnType：varchar(225), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`MU_DESC`", ColumnKey.None, false)]
		public string MuDesc { get; set; }
			
		/// <summary>
		/// 排序
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`SORT`", ColumnKey.None, false)]
		public int? Sort { get; set; }
			
		/// <summary>
		/// 创建时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`CREATE_TIME`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 角色权限
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`system_power`")]
	public partial class SystemPower
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`ID`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`PW_CODE`", ColumnKey.None, false)]
		public string PwCode { get; set; }
			
		/// <summary>
		/// 部门
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`RO_CODE`", ColumnKey.None, false)]
		public string RoCode { get; set; }
			
		/// <summary>
		/// 菜单
		/// ColumnType：text, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`MU_CODE`", ColumnKey.None, false)]
		public string MuCode { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`PW_DELETE`", ColumnKey.None, false)]
		public int? PwDelete { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`PW_SELECT`", ColumnKey.None, false)]
		public int? PwSelect { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`PW_UPDATE`", ColumnKey.None, false)]
		public int? PwUpdate { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`PW_INSERT`", ColumnKey.None, false)]
		public int? PwInsert { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`CREATE_TIME`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 系统角色
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`system_roles`")]
	public partial class SystemRoles
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`ID`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(50), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`RO_CODE`", ColumnKey.None, false)]
		public string RoCode { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(225), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`RO_NAME`", ColumnKey.None, false)]
		public string RoName { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`SORT`", ColumnKey.None, false)]
		public int? Sort { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`CREATE_TIME`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 教师基础
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`teacher_base`")]
	public partial class TeacherBase
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`teacher_name`", ColumnKey.None, false)]
		public string TeacherName { get; set; }
			
		/// <summary>
		/// 教师电话
		/// ColumnType：varchar(36), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`teacher_mobile`", ColumnKey.None, false)]
		public string TeacherMobile { get; set; }
			
		/// <summary>
		/// 描述
		/// ColumnType：varchar(1000), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`remark`", ColumnKey.None, false)]
		public string Remark { get; set; }
			
		/// <summary>
		/// 创建时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 手机验证短信
	/// 更新时间：2020-06-30 17:14:11
    /// </summary>
	[Table("`verification_code`")]
	public partial class VerificationCode
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 验证码
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`v_code`", ColumnKey.None, false)]
		public string VCode { get; set; }
			
		/// <summary>
		/// 手机号
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`v_mobile`", ColumnKey.None, false)]
		public string VMobile { get; set; }
			
		/// <summary>
		/// 是否有效
		/// ColumnType：bit(2), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`is_used`", ColumnKey.None, false)]
		public bool? IsUsed { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`out_time`", ColumnKey.None, false)]
		public DateTime? OutTime { get; set; }
	}

}



