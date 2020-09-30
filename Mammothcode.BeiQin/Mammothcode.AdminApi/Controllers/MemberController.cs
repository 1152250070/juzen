using Mammothcode.AdminService;
using Mammothcode.AdminService.Models;
using Mammothcode.AdminService.Services;
using Mammothcode.Model;
using Mammothcode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mammothcode.AdminApi.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        MemberService Service = ServiceFactory.GetService<MemberService>();

        #region 用户列表管理
        ///<summary>
        ///获取用户列表
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetMemberList(MemberModel req)
        {
            var data = Service.GetMemberList(req);
            return Ok(data);
        }
        
        #endregion



    }
}