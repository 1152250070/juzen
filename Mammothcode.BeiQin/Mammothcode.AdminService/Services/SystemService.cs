using Dapper.Linq;
using Mammothcode.AdminService.Models;
using Mammothcode.Library.Data;
using Mammothcode.Model;
using System;

namespace Mammothcode.Service
{
    /// <summary>
    /// 后台基础服务
    /// </summary>
    public class SystemService : BaseService
    {
        #region 用户登入接口
        /// <summary>
        /// 用户登入
        /// 王剑锋 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult Login(SystemAdminModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.Account))
            {
                ThrowServiceException("账号不能为空");
            }
            if (string.IsNullOrEmpty(req.Password))
            {
                ThrowServiceException("密码不能为空");
            }
            #endregion

            #region 判断用户名是否正确
            var user = DbContext.From<SystemAdmin>()
                .Where(a => a.Account == req.Account && a.Password == req.Password.ToMd5_16Bit())
                .Single();
            if (user == null)
            {
                ThrowServiceException("用户名或密码错误");
            }
            #endregion

            #region 登入成功返回模型
            var token = new SystemToken()
            {
                AuCode = user.AuCode,
                RoCode = user.RoCode,
                AuName = user.AuName,
                Account = user.Account,
                AuPower = user.AuPower ?? 0,
                ExpiryTime = DateTime.Now.AddHours(3)

            }.ToJson().ToBase64();
            var data = new
            {
                #region 用户模型
                user.AuName,
                user.AuCode,
                user.RoCode,
                user.AuPower,
                Token = token,
                #endregion
            };
            #endregion

            return Data(data);
        }

        /// <summary>
        /// 验证Token是否失效
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public IResult CheckLogin(CheckLoginModel req)
        {
            var token = SystemToken.GetToken(req.Token);

            #region 超时验证
            if (token.ExpiryTime != null && token.ExpiryTime < DateTime.Now)
            {
                return IsOk(false);
            }
            #endregion
            return Data(token);
        }
        #endregion

        #region 员工管理
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult AddUserInAdmin(SystemAdminModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.Account))
            {
                ThrowServiceException("账号不能为空");
            }
            if (string.IsNullOrEmpty(req.Password))
            {
                ThrowServiceException("密码不能为空");
            }
            if (string.IsNullOrEmpty(req.AuName))
            {
                ThrowServiceException("用户名不能为空");
            }
            if (string.IsNullOrEmpty(req.RoCode))
            {
                ThrowServiceException("角色不能为空");
            }
            #endregion

            #region 验证账号是否已存在
            if (DbContext.From<SystemAdmin>().Where(a => a.Account == req.Account).Exists())
            {
                ThrowServiceException("该账号已存在");
            }
            #endregion

            #region 保存更新
            var entity = req.NewInstance();
            entity.AuPower = 0;
            entity.CreateTime = DateTime.Now;
            entity.AuCode = RandUtil.GetTuid();
            entity.Password = req.Password.ToMd5_16Bit();
           // entity.Id = Guid.NewGuid().ToString("N");
            var row = DbContext.From<SystemAdmin>().Insert(entity);
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult UpdateUserInAdmin(SystemAdminModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.Account))
            {
                ThrowServiceException("账号不能为空");
            }
            if (string.IsNullOrEmpty(req.Password))
            {
                ThrowServiceException("密码不能为空");
            }
            if (string.IsNullOrEmpty(req.AuName))
            {
                ThrowServiceException("用户名不能为空");
            }
            #endregion

            #region 保存更新
            var entity = req.NewInstance();
            var row = DbContext.From<SystemAdmin>().Update(entity);
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult DelUserInAdmin(SystemAdminModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.AuCode))
            {
                ThrowServiceException("用户CODE不能为空");
            }
            #endregion

            #region 保存更新
            var row = DbContext.From<SystemAdmin>().Where(a => a.AuCode == req.AuCode).Delete();
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult UpdatePasswordInAdmin(SystemAdminModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.AuCode))
            {
                ThrowServiceException("用户CODE不能为空");
            }
            if (string.IsNullOrEmpty(req.Password))
            {
                ThrowServiceException("新密码不能为空");
            }
            #endregion

            #region 保存更新
            var row = DbContext.From<SystemAdmin>()
                .Set(a => a.Password, req.Password.ToMd5_16Bit())
                .Where(a => a.AuCode == req.AuCode)
                .Update();
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetUserListInAdmin(SystemAdminModel req)
        {
            var list = DbContext.From<SystemAdmin>()
                   .Where(a => Operator.Contains(a.AuName, req.AuName), !string.IsNullOrEmpty(req.AuName))
                   .Where(a => a.RoCode == req.RoCode, !string.IsNullOrEmpty(req.RoCode))
                   .Page(req, out long total)
                   .Select();

            return Data(list, total);
        }
        #endregion

        #region 角色管理
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult AddRolesInAdmin(SystemRolesModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.RoName))
            {
                ThrowServiceException("角色名称不能为空");
            }
            #endregion

            #region 保存更新
            var entity = req.NewInstance();
            entity.CreateTime = DateTime.Now;
            entity.RoCode = RandUtil.GetTuid();
            //entity.Id = Guid.NewGuid().ToString("N");
            var row = DbContext.From<SystemRoles>().Insert(entity);
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult UpdateRolesInAdmin(SystemRolesModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.RoName))
            {
                ThrowServiceException("角色名称不能为空");
            }
            #endregion

            #region 保存更新
            var entity = req.NewInstance();
            var row = DbContext.From<SystemRoles>().Update(entity);
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult DelRolesInAdmin(SystemRolesModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.RoCode))
            {
                ThrowServiceException("角色CODE不能为空");
            }
            #endregion

            #region 判断该角色下是否存在员工
            if (DbContext.From<SystemAdmin>().Where(s => s.RoCode == req.RoCode).Exists())
            {
                ThrowServiceException("请先删除该角色下的员工");
            }
            #endregion

            #region 保存更新
            var entity = req.NewInstance();
            entity.RoCode = RandUtil.GetTuid();
            var row = DbContext.From<SystemRoles>()
                .Where(d => d.RoCode == req.RoCode)
                .Delete();
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetRolesListInAdmin(SystemRolesModel req)
        {
            var list = DbContext.From<SystemRoles>()
                    .Page(req, out long total)
                    .Select();

            return Data(list, total);
        }
        #endregion

        #region 菜单管理
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult AddMenusInAdmin(SystemMenusModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.MuName))
            {
                ThrowServiceException("菜单名称不能为空");
            }
            #endregion

           // ModelPropertyClass IsIdentity = true;
            #region 保存更新
            var entity = req.NewInstance();
            //entity.Id = Guid.NewGuid().ToString("N");
            entity.MuCode = RandUtil.GetTuid();
            entity.CreateTime = DateTime.Now;
            var row = DbContext.From<SystemMenus>().Insert(entity);
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult UpdateMenusInAdmin(SystemMenusModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.MuName))
            {
                ThrowServiceException("菜单名称不能为空");
            }
            #endregion

            #region 保存更新
            var entity = req.NewInstance();
            var row = DbContext.From<SystemMenus>().Update(entity);
            #endregion
            return IsOk(row > 0);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult DelMenusInAdmin(SystemMenusModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.MuCode))
            {
                ThrowServiceException("菜单CODE不能为空");
            }
            #endregion

            #region 保存更新
            var row = DbContext.From<SystemMenus>()
                .Where(m => m.MuCode == req.MuCode)
                .Delete();
            #endregion

            return IsOk(row > 0);
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetMenusListInAdmin(SystemMenusModel req)
        {
            var list = DbContext.From<SystemMenus>()
                   .Select();
            return Data(list);
        }
        #endregion

        #region 角色权限管理
        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult UpdatePowerInAdmin(SystemPowerModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.MuCode))
            {
                ThrowServiceException("菜单CODE不能为空");
            }
            if (string.IsNullOrEmpty(req.RoCode))
            {
                ThrowServiceException("角色CODE不能为空");
            }
            #endregion

            #region 保存更新
            var entity = DbContext.From<SystemPower>().Where(m => m.RoCode == req.RoCode).Single();
            if (entity == null)
            {
                entity = req.NewInstance();

                entity.PwCode = RandUtil.GetTuid();
                entity.CreateTime = DateTime.Now;
              //  entity.Id= Guid.NewGuid().ToString("N");
                DbContext.From<SystemPower>().Insert(entity);

            }
            else
            {
                entity.MuCode = req.MuCode;
                entity.PwDelete = req.PwDelete;
                entity.PwInsert = req.PwInsert;
                entity.PwSelect = req.PwSelect;
                entity.PwUpdate = req.PwUpdate;
                DbContext.From<SystemPower>().Update(entity);
            }
            #endregion

            return IsOk(true);
        }
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetPowerInAdmin(SystemPowerModel req)
        {
            #region 非空验证
            if (string.IsNullOrEmpty(req.RoCode))
            {
                ThrowServiceException("角色CODE不能为空");
            }
            #endregion

            #region 获取角色权限
            var entity = DbContext.From<SystemPower>()
                .Where(m => m.RoCode == req.RoCode)
                .Single();
            #endregion

            return Data(entity);

        }
        #endregion

    }

    /// <summary>
    /// 登入信息
    /// </summary>
    public class SystemToken
    {
        public string AuCode { get; set; }
        public string RoCode { get; set; }
        public string Account { get; set; }
        public int AuPower { get; set; }
        public string AuName { get; set; }
        public DateTime ExpiryTime { get; set; }
        public static SystemToken GetToken(string token)
        {
            return token.FromBase64().FromJson<SystemToken>();
        }

    }
    public class CheckLoginModel
    {
        public string Token { get; set; }
    }



}
