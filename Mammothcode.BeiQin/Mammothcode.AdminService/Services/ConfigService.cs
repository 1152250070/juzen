using Dapper.Linq;
using Mammothcode.AdminService.Models;
using Mammothcode.Model;
using Mammothcode.Service;
using System;

namespace Mammothcode.AdminService.Services
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class ConfigService : BaseService
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
        /// <summary>
        /// 修改系统配置
        /// </summary>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual IResult UpdateSystem(SystemConfigModel req)
        {
            var entity = req.NewInstance();
            if (entity.Id == null)
            {
                var id = DbContext.From<SystemConfig>()
                                .InsertReturnId(entity);
                return Data(id);
            }
            var row = DbContext.From<SystemConfig>()
                                 .Update(entity);

            return Data(row > 0);
        }
    }
}
