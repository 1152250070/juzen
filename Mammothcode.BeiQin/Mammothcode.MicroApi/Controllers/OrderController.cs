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
    /// 预约
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService Service = ServiceFactory.GetService<OrderService>();

    }
}
