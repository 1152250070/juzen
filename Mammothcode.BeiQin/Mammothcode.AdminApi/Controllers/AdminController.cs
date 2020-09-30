using Mammothcode.Model;
using Mammothcode.Service;
using Microsoft.AspNetCore.Mvc;

namespace Mammothcode.AdminApi.Controllers
{
    /// <summary>
    ///登录
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        SystemService SystemService = ServiceFactory.GetService<SystemService>();

        #region 用户登入
        [HttpPost]
        public IActionResult Login(SystemAdminModel req)
        {
            var data = SystemService.Login(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult CheckLogin(CheckLoginModel req)
        {
            var data = SystemService.CheckLogin(req);
            return Ok(data);
        }
        #endregion

        #region 员工管理
        [HttpPost]
        public IActionResult AddUserInAdmin(SystemAdminModel req)
        {
            var data = SystemService.AddUserInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult UpdateUserInAdmin(SystemAdminModel req)
        {
            var data = SystemService.UpdateUserInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult UpdatePasswordInAdmin(SystemAdminModel req)
        {
            var data = SystemService.UpdatePasswordInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult DelUserInAdmin(SystemAdminModel req)
        {
            var data = SystemService.DelUserInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult GetUserListInAdmin(SystemAdminModel req)
        {
            var data = SystemService.GetUserListInAdmin(req);
            return Ok(data);
        }
        #endregion

        #region 菜单管理
        [HttpPost]
        public IActionResult AddMenusInAdmin(SystemMenusModel req)
        {
            var data = SystemService.AddMenusInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult UpdateMenusInAdmin(SystemMenusModel req)
        {
            var data = SystemService.UpdateMenusInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult DelMenusInAdmin(SystemMenusModel req)
        {
            var data = SystemService.DelMenusInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult GetMenusListInAdmin(SystemMenusModel req)
        {
            var data = SystemService.GetMenusListInAdmin(req);
            return Ok(data);
        }

        #endregion

        #region 角色管理
        [HttpPost]
        public IActionResult AddRolesInAdmin(SystemRolesModel req)
        {
            var data = SystemService.AddRolesInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult UpdateRolesInAdmin(SystemRolesModel req)
        {
            var data = SystemService.UpdateRolesInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult DelRolesInAdmin(SystemRolesModel req)
        {
            var data = SystemService.DelRolesInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult GetRolesListInAdmin(SystemRolesModel req)
        {
            var data = SystemService.GetRolesListInAdmin(req);
            return Ok(data);
        }

        #endregion

        #region 权限管理
        [HttpPost]
        public IActionResult UpdatePowerInAdmin(SystemPowerModel req)
        {
            var data = SystemService.UpdatePowerInAdmin(req);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult GetPowerInAdmin(SystemPowerModel req)
        {
            var data = SystemService.GetPowerInAdmin(req);
            return Ok(data);
        }
        #endregion

    }
}