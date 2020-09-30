using Mammothcode.Wechat;
using System;
using System.Collections.Generic;
using System.Text;
using Mammothcode.Library.Data;
using Mammothcode.Library.API;
using System.Linq;
using Mammothcode.Service;
using Mammothcode.Model;
using Mammothcode.MicroService.Models;

namespace Mammothcode.MicroService.Services
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class ConfigService:BaseService
    {


        /// <summary>
        /// 获取系统配置
        /// </summary>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult GetSystem()
        {
            var data = DbContext.From<SystemConfig>()
                               .Single();
            return Data(data);
        }
    }
}
