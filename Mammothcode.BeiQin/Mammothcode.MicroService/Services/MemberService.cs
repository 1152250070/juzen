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
using Dapper.Linq;

namespace Mammothcode.MicroService.Services
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class MemberService : BaseService
    {
        #region 用户注册、获取用户信息

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(true)]
        public virtual ResultsMemInfm MemberRegister(string code)
        {

            Member entity = new Member();
            string openid = string.Empty;
            string NickName = string.Empty;
            string access_token = string.Empty;
            string headimgurl = string.Empty;


            //h5根据code换取网页授权access_token
            if (!string.IsNullOrEmpty(code))
            {
                #region 微信授权
                var json = AuthUtil.GetH5UserToken(code);//获取openid和access_token
                var jsonObject = json.FromJsonObject();
                Warn("微信授权失败" + json);
                if (jsonObject?.GetValue("openid") == null)
                {
                    Warn("微信授权失败" + json);
                    throw new ServiceException("微信授权失败：" + json);
                }
                openid = jsonObject["openid"].ToString().Trim();
                access_token = jsonObject["access_token"].ToString().Trim();
                #endregion

            }
            //获取用户信息
            if (!string.IsNullOrWhiteSpace(openid) && !string.IsNullOrWhiteSpace(access_token))
            {
                var userInfmJson = AuthUtil.GetH5UserInfoSubscribe(access_token, openid);
                var userInfmObject = userInfmJson.FromJsonObject();
                entity.NickName = userInfmObject["nickname"].ToString().Trim();
                entity.HeadImg = userInfmObject["headimgurl"].ToString().Trim();
                entity.Subscribe = userInfmObject["subscribe"] != null ? Convert.ToInt32(userInfmObject["subscribe"]) : 0;
            }
            else
            {
                throw new ServiceException("微信授权失败");
            }

            if (DbContext.From<Member>().Where(a => a.OpenId == openid).Exists())
            {
                ThrowServiceException("用户已注册");
            }
            entity.OpenId = openid;
            entity.CreateTime = DateTime.Now;

            var id = DbContext.From<Member>().InsertReturnId(entity);
            return new ResultsMemInfm()
            {
                MId = (int)id,
                Subscribe = entity.Subscribe,
            };
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetMember(GetMemberInfoModel req)
        {
            try
            {
                Member member = null;
                if (!string.IsNullOrEmpty(req.JsCode))
                {
                    #region 微信授权
                    var json = AuthUtil.GetUserToken(req.JsCode).FromJsonObject();
                    if (json?.GetValue("openid") == null)
                    {
                        throw new ServiceException("微信授权失败");
                    }
                    req.OpenId = json["openid"].ToString().Trim();
                    #endregion
                    member = DbContext.From<Member>()
                    .Where(a => a.OpenId == req.OpenId)
                    .Single();
                }
                else if (!string.IsNullOrEmpty(req.Token))
                {
                    var tokens = MemberToken.GetToken(req.Token);
                    member = DbContext.From<Member>()
                      .Where(a => a.Id == tokens.MId)
                      .Single();
                    if (member == null)
                    {
                        ThrowServiceException("Token失效");
                    }
                }
                else if (member == null)
                {
                    ThrowServiceException("Token失效");
                }

                #region Token组装

                var token = new MemberToken()
                {
                    HeadImg = member.HeadImg,
                    MId = member.Id,
                    NickName = member.NickName,
                    RealName = member.RealName,
                    OpenId = member.OpenId,
                }.ToJson().ToBase64();

                #endregion

                return Data(member);
            }
            catch (Exception e)
            {

                ThrowServiceException(e.Message);
                return Data(e.Message);
            }
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult SetMemberInfm(SetMemberInfmModel req)
        {
            var token = MemberToken.GetToken(req.Token);
            var data = DbContext.From<Member>()
                                .Set(a => a.HeadImg, req.HeadImg, !string.IsNullOrEmpty(req.HeadImg))
                                .Set(a => a.NickName, req.NickName, !string.IsNullOrEmpty(req.NickName))
                                .Set(a => a.RealName, req.RealName, !string.IsNullOrEmpty(req.RealName))
                                .Where(a => a.Id == token.MId)
                                .Update();
            return Data(data);
        }
        #endregion

        #region 用户观看记录
        /// <summary>
        /// 获取观看记录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult GetCourseLookRecord(GetCourseLookRecordModel req)
        {
            var token = MemberToken.GetToken(req.Token);
            var data = DbContext.From<GoodCourse, CourseLook>()
                                .Join((a, b) => a.Id == b.CourseId)
                                .Where((a, b) => b.MId == token.MId)
                                .OrderByDescending((a, b) => b.Id)
                                .Select((a, b) => new
                                {
                                    a.TImg,
                                    a.CourseName,
                                    a.CourseTitle,
                                    b.CreateTime,
                                });
            return Data(data);
        }
        /// <summary>
        ///删除观看历史
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [ServiceDbContext(false)]
        public virtual IResult DelCourseLook(DelCourseLookModel req)
        {

            var data = DbContext.From<CourseLook>()
                                .Where(a => a.Id == req.Id)
                                .Delete();
            return Data(data);
        }
        #endregion
    }
}
