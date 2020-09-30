using Mammothcode.Library.Data;
using Mammothcode.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mammothcode.MicroService.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberToken
    {
        public int? MId { get; set; }
        public string NickName { get; set; }
        public string HeadImg { get; set; }
        public string OpenId { get; set; }
        public string RealName { get; set; }
        public int? StudentId { get; set; }
        public static MemberToken GetToken(string token)
        {
            return token.FromBase64().FromJson<MemberToken>();
        }
        public string NewToken()
        {
            return this.ToJson().ToBase64();
        }
    }

   
  
    /// <summary>
    ///
    /// </summary>
    public class GetMemberInfoModel
    {
        public string JsCode { get; set; }

        public string Token { get; set; }

        public string OpenId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string MemberId { get; set; }
    }
    /// <summary>
    /// 修改用户信息
    /// </summary>
    public class SetMemberInfmModel:TokenModel 
    {
        public string HeadImg { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public int MonthAge { get; set; }
    }
    public class GetCourseLookRecordModel:TokenModel 
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class DelCourseLookModel : TokenModel 
    {
        [Required]
        public int Id { get; set; }

    }
    public class ResultsMemInfm 
    {
        public int MId { get; set; }
        public int? Subscribe { get; set; }
    }
}
