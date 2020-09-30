

using System;
using Dapper.Linq;

namespace Mammothcode.Model
{

	/// <summary>
    /// 评论点赞
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class CommentZanModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? CommentId { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? MId { get; set; }
			
		/// <summary>
		/// 微信头像
		/// </summary>
		public string HeadImg { get; set; }
			
		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName { get; set; }
			
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string RealName { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public CommentZan NewInstance()
		{
			return new CommentZan()
			{
    			Id = this.Id,
    			CommentId = this.CommentId,
    			MId = this.MId,
    			HeadImg = this.HeadImg,
    			NickName = this.NickName,
    			RealName = this.RealName,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 课程评论
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class CourseCommentModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? MId { get; set; }
			
		/// <summary>
		/// 微信头像
		/// </summary>
		public string HeadImg { get; set; }
			
		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName { get; set; }
			
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string RealName { get; set; }
			
		/// <summary>
		/// 评论内容
		/// </summary>
		public string CContent { get; set; }
			
		/// <summary>
		/// 点赞数量
		/// </summary>
		public int? ZanNum { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public CourseComment NewInstance()
		{
			return new CourseComment()
			{
    			Id = this.Id,
    			CourseId = this.CourseId,
    			MId = this.MId,
    			HeadImg = this.HeadImg,
    			NickName = this.NickName,
    			RealName = this.RealName,
    			CContent = this.CContent,
    			ZanNum = this.ZanNum,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 课程观看历史
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class CourseLookModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? MId { get; set; }
			
		/// <summary>
		/// 观看时间
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public CourseLook NewInstance()
		{
			return new CourseLook()
			{
    			Id = this.Id,
    			CourseId = this.CourseId,
    			MId = this.MId,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 课程点赞
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class CourseZanModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? CourseId { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? MId { get; set; }
			
		/// <summary>
		/// 微信头像
		/// </summary>
		public string HeadImg { get; set; }
			
		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName { get; set; }
			
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string RealName { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public CourseZan NewInstance()
		{
			return new CourseZan()
			{
    			Id = this.Id,
    			CourseId = this.CourseId,
    			MId = this.MId,
    			HeadImg = this.HeadImg,
    			NickName = this.NickName,
    			RealName = this.RealName,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 课程
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class GoodCourseModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 课程名称
		/// </summary>
		public string CourseName { get; set; }
			
		/// <summary>
		/// 课程专题
		/// </summary>
		public string CourseTitle { get; set; }
			
		/// <summary>
		/// 课程图片
		/// </summary>
		public string CourseImg { get; set; }
			
		/// <summary>
		/// 教师头像
		/// </summary>
		public string TImg { get; set; }
			
		/// <summary>
		/// 教师名称
		/// </summary>
		public string TName { get; set; }
			
		/// <summary>
		/// 教师简介
		/// </summary>
		public string TIntroduction { get; set; }
			
		/// <summary>
		/// 点赞数量
		/// </summary>
		public int? ZanNum { get; set; }
			
		/// <summary>
		/// 评论数量
		/// </summary>
		public int? CommentsNum { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		/// <summary>
		/// 课程类型0=录播，1=直播
		/// </summary>
		public int? CourseType { get; set; }
			
		/// <summary>
		/// 状态
		/// </summary>
		public int? Status { get; set; }
			
		/// <summary>
		/// 课程链接
		/// </summary>
		public string CourseUrl { get; set; }
			
		/// <summary>
		/// 直播开始时间
		/// </summary>
		public DateTime? LiveTime { get; set; }
			
		/// <summary>
		/// 直播地址
		/// </summary>
		public string LiveUrl { get; set; }
			
		/// <summary>
		/// 是否是最新
		/// </summary>
		public bool? IsNew { get; set; }
			
		/// <summary>
		/// 是否热门
		/// </summary>
		public bool? IsHot { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? LookNum { get; set; }
			
		public GoodCourse NewInstance()
		{
			return new GoodCourse()
			{
    			Id = this.Id,
    			CourseName = this.CourseName,
    			CourseTitle = this.CourseTitle,
    			CourseImg = this.CourseImg,
    			TImg = this.TImg,
    			TName = this.TName,
    			TIntroduction = this.TIntroduction,
    			ZanNum = this.ZanNum,
    			CommentsNum = this.CommentsNum,
    			CreateTime = this.CreateTime,
    			CourseType = this.CourseType,
    			Status = this.Status,
    			CourseUrl = this.CourseUrl,
    			LiveTime = this.LiveTime,
    			LiveUrl = this.LiveUrl,
    			IsNew = this.IsNew,
    			IsHot = this.IsHot,
    			LookNum = this.LookNum,
    		};
		}
	}
	/// <summary>
    /// 用户表
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class MemberModel : PageModel
	{
				
		/// <summary>
		/// 编号
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 用户手机号码
		/// </summary>
		public string Mobile { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public string OpenId { get; set; }
			
		/// <summary>
		/// 微信头像
		/// </summary>
		public string HeadImg { get; set; }
			
		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName { get; set; }
			
		/// <summary>
		/// 是否关注值为0时
		/// </summary>
		public int? Subscribe { get; set; }
			
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string RealName { get; set; }
			
		/// <summary>
		/// 宝宝年龄
		/// </summary>
		public int? BabyMonthAge { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public Member NewInstance()
		{
			return new Member()
			{
    			Id = this.Id,
    			Mobile = this.Mobile,
    			OpenId = this.OpenId,
    			HeadImg = this.HeadImg,
    			NickName = this.NickName,
    			Subscribe = this.Subscribe,
    			RealName = this.RealName,
    			BabyMonthAge = this.BabyMonthAge,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 系统管理员
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class SystemAdminModel : PageModel
	{
				
		/// <summary>
		/// ID
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 后台用户CODE
		/// </summary>
		public string AuCode { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public string RoCode { get; set; }
			
		/// <summary>
		/// 后台用户名称
		/// </summary>
		public string AuName { get; set; }
			
		/// <summary>
		/// 描述
		/// </summary>
		public string AuDesc { get; set; }
			
		/// <summary>
		/// 管理员账号
		/// </summary>
		public string Account { get; set; }
			
		/// <summary>
		/// 职务
		/// </summary>
		public string AuPost { get; set; }
			
		/// <summary>
		/// 手机号
		/// </summary>
		public string AuMobile { get; set; }
			
		/// <summary>
		/// 性别
		/// </summary>
		public int? AuSex { get; set; }
			
		/// <summary>
		/// -1超级管理员是否超级管理
		/// </summary>
		public int? AuPower { get; set; }
			
		/// <summary>
		/// 密码
		/// </summary>
		public string Password { get; set; }
			
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public SystemAdmin NewInstance()
		{
			return new SystemAdmin()
			{
    			Id = this.Id,
    			AuCode = this.AuCode,
    			RoCode = this.RoCode,
    			AuName = this.AuName,
    			AuDesc = this.AuDesc,
    			Account = this.Account,
    			AuPost = this.AuPost,
    			AuMobile = this.AuMobile,
    			AuSex = this.AuSex,
    			AuPower = this.AuPower,
    			Password = this.Password,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 公司基础信息配置表
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class SystemConfigModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 首页图片
		/// </summary>
		public string IndexImg { get; set; }
			
		public SystemConfig NewInstance()
		{
			return new SystemConfig()
			{
    			Id = this.Id,
    			IndexImg = this.IndexImg,
    		};
		}
	}
	/// <summary>
    /// 系统菜单
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class SystemMenusModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 菜单CODE
		/// </summary>
		public string MuCode { get; set; }
			
		/// <summary>
		/// 父节点菜单
		/// </summary>
		public string PmuCode { get; set; }
			
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string MuName { get; set; }
			
		/// <summary>
		/// 0内容，1系统
		/// </summary>
		public int? MuType { get; set; }
			
		/// <summary>
		/// 是否子节点
		/// </summary>
		public int? IsChild { get; set; }
			
		/// <summary>
		/// 跳转链接
		/// </summary>
		public string MuUrl { get; set; }
			
		/// <summary>
		/// 图标
		/// </summary>
		public string MuIcon { get; set; }
			
		/// <summary>
		/// 功能描述
		/// </summary>
		public string MuDesc { get; set; }
			
		/// <summary>
		/// 排序
		/// </summary>
		public int? Sort { get; set; }
			
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public SystemMenus NewInstance()
		{
			return new SystemMenus()
			{
    			Id = this.Id,
    			MuCode = this.MuCode,
    			PmuCode = this.PmuCode,
    			MuName = this.MuName,
    			MuType = this.MuType,
    			IsChild = this.IsChild,
    			MuUrl = this.MuUrl,
    			MuIcon = this.MuIcon,
    			MuDesc = this.MuDesc,
    			Sort = this.Sort,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 角色权限
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class SystemPowerModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public string PwCode { get; set; }
			
		/// <summary>
		/// 部门
		/// </summary>
		public string RoCode { get; set; }
			
		/// <summary>
		/// 菜单
		/// </summary>
		public string MuCode { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? PwDelete { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? PwSelect { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? PwUpdate { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? PwInsert { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public SystemPower NewInstance()
		{
			return new SystemPower()
			{
    			Id = this.Id,
    			PwCode = this.PwCode,
    			RoCode = this.RoCode,
    			MuCode = this.MuCode,
    			PwDelete = this.PwDelete,
    			PwSelect = this.PwSelect,
    			PwUpdate = this.PwUpdate,
    			PwInsert = this.PwInsert,
    			CreateTime = this.CreateTime,
    		};
		}
	}
	/// <summary>
    /// 系统角色
	/// 更新时间：2020-09-22 18:04:42
    /// </summary>
	public partial class SystemRolesModel : PageModel
	{
				
		/// <summary>
		/// 
		/// </summary>
		public int? Id { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public string RoCode { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public string RoName { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public int? Sort { get; set; }
			
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime { get; set; }
			
		public SystemRoles NewInstance()
		{
			return new SystemRoles()
			{
    			Id = this.Id,
    			RoCode = this.RoCode,
    			RoName = this.RoName,
    			Sort = this.Sort,
    			CreateTime = this.CreateTime,
    		};
		}
	}

}



