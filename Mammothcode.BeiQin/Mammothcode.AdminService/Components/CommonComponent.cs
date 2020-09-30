using Mammothcode.AdminService.Components;
using Mammothcode.Model;
using Mammothcode.Service;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Mammothcode.Service
{
    public class CommonComponent : BaseComponent
    {

        #region 获取运费
        /// <summary>
        /// 获取运费
        /// </summary>
        /// <param name="ProvinceCode">省code</param>
        /// <param name="CityCode">市code</param>
        /// <returns></returns>
        public decimal GetPostFee(string ProvinceCode, string CityCode)
        {
            var entity = DbContext.From<ProductFreight>()
                .Where(a => a.ProvinceCode == ProvinceCode && a.CityCode == CityCode)
                .Single();

            if (entity == null)
            {
                entity = DbContext.From<ProductFreight>()
                 .Where(a => a.ProvinceCode == "0" && a.CityCode == "0")
                 .Single();
            }

            return entity.PostFee ?? 0;
        }
        #endregion

        #region 修改余额
        /// <summary>
        /// 修改用户余额
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="score">积分</param>
        /// <param name="remark">说明</param>
        public void SetMemberScoreBalance(int? id, decimal? score, string remark)
        {
            if (score == 0 || score == null)
            {
                return;
            }
            var result = Math.Abs(score??0);
            var row = DbContext.From<Member>()
                 .Set(a => a.BalanceScore, a => a.BalanceScore + score)
                 .Where(a => a.Id == id)
                 .Where(a => a.BalanceScore >= result, score < 0)
                 .Update();

            if (row != 1)
            {
                throw new ServiceException($"支付失败：余额不足");
            }

            DbContext.From<MemberScoreBill>().Insert(new MemberScoreBill()
            {
                CreateTime = DateTime.Now,
                MemberId = id,
                Remark = remark,
                Score = score
            });
        }
        /// <summary>
        /// 修改用户余额
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="amount">金额</param>
        /// <param name="remark">说明</param>
        public void SetMemberCashBalance(int? id, decimal? amount, string remark)
        {
            if (amount == 0 || amount == null)
            {
                return;
            }
            var result = Math.Abs(amount ?? 0);
            var row = DbContext.From<Member>()
                 .Set(a => a.BalanceCash, a => a.BalanceCash + amount)
                 .Where(a => a.Id == id)
                 .Where(a => a.BalanceCash >= result, amount < 0)
                 .Update();

            if (row != 1)
            {
                throw new ServiceException($"支付失败：余额不足");
            }

            DbContext.From<MemberCashBill>().Insert(new MemberCashBill()
            {
                CreateTime = DateTime.Now,
                MemberId = id,
                Remark = remark,
                Amount = amount
            });
        }
        #endregion


        #region  发送内部消息通知

        public void SendMessage(int? memberid, string title, int type, string remark, string url)
        {
            DbContext.From<MemberMessage>().Insert(new MemberMessage()
            {
                CreateTime = DateTime.Now,
                MemberId = memberid,
                MsgIsRead = false,
                MsgTitle = title,
                MsgType = type,
                MsgText = remark,
                MsgTargetUrl = url
            });
        }

        public static string GetSourceValue(string key)
        {
            ResourceManager resManagerB = new ResourceManager("Mammothcode.AdminService.Components.MessageMould", typeof(MessageMould).Assembly);
            string value = resManagerB.GetString(key);
            return value;
        }
        #endregion

    }
}
