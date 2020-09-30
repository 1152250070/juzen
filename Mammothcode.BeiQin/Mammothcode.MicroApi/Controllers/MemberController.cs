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

namespace Mammothcode.MicroApi.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        MemberService Service = ServiceFactory.GetService<MemberService>();

        #region 用户注册、获取用户信息、
        ///<summary>
        ///用户注册
        ///</summary>
        ///<returns></returns>
        [HttpGet("{code}")]
        public IActionResult MemberRegister(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return File($"./index.html?", "text/html");
            }
            var data = Service.MemberRegister(code);
            string url = string.Format("/index.html?MId={0}&Subscribe={1}", data.MId, data.Subscribe);
            return File(url, "text/html");
        }
        ///<summary>
        ///获取用户基本信息
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetMember(GetMemberInfoModel req)
        {
            var data = Service.GetMember(req);
            return Ok(data);
        }
        ///<summary>
        ///修改用户信息
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult SetMemberInfm(SetMemberInfmModel req)
        {
            var data = Service.SetMemberInfm(req);
            return Ok(data);
        }
        #endregion

        #region 用户观看记录
        ///<summary>
        ///获取观看记录
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult GetCourseLookRecord(GetCourseLookRecordModel req)
        {
            var data = Service.GetCourseLookRecord(req);
            return Ok(data);
        }
        ///<summary>
        ///删除观看历史
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult DelCourseLook(DelCourseLookModel req)
        {
            var data = Service.DelCourseLook(req);
            return Ok(data);
        }
        #endregion

    }
}
