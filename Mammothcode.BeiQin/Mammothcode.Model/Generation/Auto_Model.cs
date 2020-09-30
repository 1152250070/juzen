

using System;
using Dapper.Linq;

namespace Mammothcode.Model
{

	
	/// <summary>
    /// 评论点赞
	/// 更新时间：2020-09-22 18:04:33
    /// </summary>
	[Table("`comment_zan`")]
	public partial class CommentZan
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`comment_id`", ColumnKey.None, false)]
		public int? CommentId { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
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
		/// ColumnType：varchar(255), IsNull：YES, Default：
		/// </summary>
		[Column("`real_name`", ColumnKey.None, false)]
		public string RealName { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 课程评论
	/// 更新时间：2020-09-22 18:04:33
    /// </summary>
	[Table("`course_comment`")]
	public partial class CourseComment
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_id`", ColumnKey.None, false)]
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
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
		/// ColumnType：varchar(255), IsNull：YES, Default：
		/// </summary>
		[Column("`real_name`", ColumnKey.None, false)]
		public string RealName { get; set; }
			
		/// <summary>
		/// 评论内容
		/// ColumnType：varchar(500), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`c_content`", ColumnKey.None, false)]
		public string CContent { get; set; }
			
		/// <summary>
		/// 点赞数量
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`zan_num`", ColumnKey.None, false)]
		public int? ZanNum { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 课程观看历史
	/// 更新时间：2020-09-22 18:04:33
    /// </summary>
	[Table("`course_look`")]
	public partial class CourseLook
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_id`", ColumnKey.None, false)]
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
		/// <summary>
		/// 观看时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 课程点赞
	/// 更新时间：2020-09-22 18:04:33
    /// </summary>
	[Table("`course_zan`")]
	public partial class CourseZan
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_id`", ColumnKey.None, false)]
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`m_id`", ColumnKey.None, false)]
		public int? MId { get; set; }
			
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
		/// ColumnType：varchar(255), IsNull：YES, Default：
		/// </summary>
		[Column("`real_name`", ColumnKey.None, false)]
		public string RealName { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 课程
	/// 更新时间：2020-09-22 18:04:33
    /// </summary>
	[Table("`good_course`")]
	public partial class GoodCourse
	{
				
		/// <summary>
		/// 
		/// ColumnType：int(10), IsNull：NO, Default：NULL
		/// </summary>
		[Column("`id`", ColumnKey.Primary, true)]
		public int? Id { get; set; }
			
		/// <summary>
		/// 课程名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_name`", ColumnKey.None, false)]
		public string CourseName { get; set; }
			
		/// <summary>
		/// 课程专题
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_title`", ColumnKey.None, false)]
		public string CourseTitle { get; set; }
			
		/// <summary>
		/// 课程图片
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_img`", ColumnKey.None, false)]
		public string CourseImg { get; set; }
			
		/// <summary>
		/// 教师头像
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`t_img`", ColumnKey.None, false)]
		public string TImg { get; set; }
			
		/// <summary>
		/// 教师名称
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`t_name`", ColumnKey.None, false)]
		public string TName { get; set; }
			
		/// <summary>
		/// 教师简介
		/// ColumnType：varchar(500), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`t_introduction`", ColumnKey.None, false)]
		public string TIntroduction { get; set; }
			
		/// <summary>
		/// 点赞数量
		/// ColumnType：int(6), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`zan_num`", ColumnKey.None, false)]
		public int? ZanNum { get; set; }
			
		/// <summary>
		/// 评论数量
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`comments_num`", ColumnKey.None, false)]
		public int? CommentsNum { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
			
		/// <summary>
		/// 课程类型0=录播，1=直播
		/// ColumnType：int(10), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_type`", ColumnKey.None, false)]
		public int? CourseType { get; set; }
			
		/// <summary>
		/// 状态
		/// ColumnType：int(2), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`status`", ColumnKey.None, false)]
		public int? Status { get; set; }
			
		/// <summary>
		/// 课程链接
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`course_url`", ColumnKey.None, false)]
		public string CourseUrl { get; set; }
			
		/// <summary>
		/// 直播开始时间
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`live_time`", ColumnKey.None, false)]
		public DateTime? LiveTime { get; set; }
			
		/// <summary>
		/// 直播地址
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`live_url`", ColumnKey.None, false)]
		public string LiveUrl { get; set; }
			
		/// <summary>
		/// 是否是最新
		/// ColumnType：bit(1), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`is_new`", ColumnKey.None, false)]
		public bool? IsNew { get; set; }
			
		/// <summary>
		/// 是否热门
		/// ColumnType：bit(1), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`is_hot`", ColumnKey.None, false)]
		public bool? IsHot { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：int(11), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`look_num`", ColumnKey.None, false)]
		public int? LookNum { get; set; }
	}
	
	/// <summary>
    /// 用户表
	/// 更新时间：2020-09-22 18:04:33
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
		/// ColumnType：varchar(36), IsNull：YES, Default：NULL
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
		/// 是否关注值为0时
		/// ColumnType：int(2), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`subscribe`", ColumnKey.None, false)]
		public int? Subscribe { get; set; }
			
		/// <summary>
		/// 用户姓名
		/// ColumnType：varchar(255), IsNull：YES, Default：
		/// </summary>
		[Column("`real_name`", ColumnKey.None, false)]
		public string RealName { get; set; }
			
		/// <summary>
		/// 宝宝年龄
		/// ColumnType：int(4), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`baby_month_age`", ColumnKey.None, false)]
		public int? BabyMonthAge { get; set; }
			
		/// <summary>
		/// 
		/// ColumnType：datetime, IsNull：YES, Default：NULL
		/// </summary>
		[Column("`create_time`", ColumnKey.None, false)]
		public DateTime? CreateTime { get; set; }
	}
	
	/// <summary>
    /// 系统管理员
	/// 更新时间：2020-09-22 18:04:33
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
	/// 更新时间：2020-09-22 18:04:33
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
		/// 首页图片
		/// ColumnType：varchar(255), IsNull：YES, Default：NULL
		/// </summary>
		[Column("`index_img`", ColumnKey.None, false)]
		public string IndexImg { get; set; }
	}
	
	/// <summary>
    /// 系统菜单
	/// 更新时间：2020-09-22 18:04:33
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
	/// 更新时间：2020-09-22 18:04:33
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
	/// 更新时间：2020-09-22 18:04:33
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

}



