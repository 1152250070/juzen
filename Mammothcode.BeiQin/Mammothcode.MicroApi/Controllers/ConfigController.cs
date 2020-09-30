using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mammothcode.MicroService.Components;
using Mammothcode.MicroService.Models;
using Mammothcode.MicroService.Services;
using Mammothcode.Model;
using Mammothcode.Service;
using Mammothcode.Wechat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Standard.Library.API;

namespace Mammothcode.MicroApi.Controllers
{
    /// <summary>
    /// 系统配置
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        ConfigService Service = ServiceFactory.GetService<ConfigService>();

        ///<summary>
        ///获取系统配置
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetSystem()
        {
            var data = Service.GetSystem();
            return Ok(data);
        }
    }
}
