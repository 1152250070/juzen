using Dapper.Linq;
using Mammothcode.AdminService.Models;
using Mammothcode.Model;
using Mammothcode.Service;
using System;

namespace Mammothcode.AdminService.Services
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class MemberService : BaseService
    {
        #region 用户列表管理
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetMemberList(MemberModel req)
        {
            var list = DbContext.From<Member>()
                                .Where(a => Operator.Contains(a.NickName, req.NickName), !string.IsNullOrWhiteSpace(req.NickName))
                                .Where(a => Operator.Contains(a.Mobile, req.Mobile), !string.IsNullOrWhiteSpace(req.Mobile))
                                .Where(a => Operator.Contains(a.RealName, req.RealName), !string.IsNullOrWhiteSpace(req.RealName))
                                .OrderByDescending(a => a.Id)
                                .Page(req, out long total)
                                .Select();
            return Data(list, total);
        }

       
        #endregion

       

    }
}
