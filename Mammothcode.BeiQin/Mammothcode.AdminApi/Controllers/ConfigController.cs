using Mammothcode.AdminService;
using Mammothcode.AdminService.Models;
using Mammothcode.AdminService.Services;
using Mammothcode.Model;
using Mammothcode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Standard.Library.API;

namespace Mammothcode.AdminApi.Controllers
{
    /// <summary>
    /// 系統配置
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigController:ControllerBase
    {
        ConfigService Service = ServiceFactory.GetService<ConfigService>();

        #region  系统配置管理
        ///<summary>
        ///获取配置项
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetSystem()
        {
            var data = Service.GetSystem();
            return Ok(data);
        }

        ///<summary>
        ///修改配置
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult UpdateSystem(SystemConfigModel req)
        {
            var data = Service.UpdateSystem(req);
            return Ok(data);
        }
        #endregion

    }
}
