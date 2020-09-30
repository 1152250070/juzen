using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;


namespace Mammothcode.Wechat
{
    /// <summary>
    /// 微信支付API
    /// </summary>
    public class PayUtil
    {

        #region 支付接口
        /// <summary>
        /// 扫码支付
        /// </summary>
        /// <param name="data"></param>

        /// <returns></returns>
        public static PayData Micropay(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/micropay";

            #region 检测必填参数:
            if (!data.IsSet("body"))
            {
                throw new Exception("数据包中,缺少必填参数:body");
            }
            else if (!data.IsSet("out_trade_no"))
            {
                throw new Exception("数据包中,缺少必填参数:out_trade_no");
            }
            else if (!data.IsSet("total_fee"))
            {
                throw new Exception("数据包中,缺少必填参数:total_fee");
            }
            else if (!data.IsSet("auth_code"))
            {
                throw new Exception("数据包中,缺少必填参数:auth_code");
            }
            #endregion

            #region 添加必须参数
            data.SetValue("spbill_create_ip", Wechat_Config.MchIP);//终端ip
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            string xml = HttpUtil.Post(new HttpItem()
            {
                Method = "POST",
                ContentType = "text/xml",
                URL = url,
                Data = data.ToXml(),
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PayData OrderQuery(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/orderquery";

            #region 检测必填参数:
            //检测必填参数:
            if (!data.IsSet("out_trade_no") && !data.IsSet("transaction_id"))
            {
                throw new Exception("订单查询接口中,out_trade_no、transaction_id至少填一个");
            }
            #endregion

            #region 添加必填参数:
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString("N"));//随机字符串
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求           
            //调用HTTP通信接口提交数据
            string xml = HttpUtil.Post(new HttpItem()
            {
                Method = "POST",
                ContentType = "text/xml",
                URL = url,
                Data = data.ToXml(),
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }

        /// <summary>
        /// 撤销订单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PayData Reverse(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/reverse";

            #region 检测必填参数:
            if (!data.IsSet("out_trade_no") && !data.IsSet("transaction_id"))
            {
                throw new Exception("撤销订单API接口中，参数out_trade_no和transaction_id必须填写一个");
            }
            #endregion

            #region 添加必填参数:
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString("N"));//随机字符串
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            string xml = HttpUtil.Post(new HttpItem()
            {
                Method = "POST",
                ContentType = "text/xml",
                URL = url,
                Data = data.ToXml(),
                X509Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate(Wechat_Config.SSlCertFilename, Wechat_Config.SSlCertPassword, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.PersistKeySet | System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.MachineKeySet)
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }

        /// <summary>
        /// 申请退款
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PayData Refund(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";

            #region 检测必填参数:
            if (!data.IsSet("out_trade_no") && !data.IsSet("transaction_id"))
            {
                throw new Exception("退款申请接口中，out_trade_no、transaction_id至少填一个");
            }
            else if (!data.IsSet("out_refund_no"))
            {
                throw new Exception("退款申请接口中，缺少必填参数:out_refund_no");
            }
            else if (!data.IsSet("total_fee"))
            {
                throw new Exception("退款申请接口中，缺少必填参数:total_fee");
            }
            else if (!data.IsSet("refund_fee"))
            {
                throw new Exception("退款申请接口中，缺少必填参数:refund_fee");
            }
            else if (!data.IsSet("op_user_id"))
            {
                throw new Exception("退款申请接口中，缺少必填参数:op_user_id");
            }
            #endregion

            #region 添加必填参数:
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            //调用HTTP通信接口提交数据到API
            string xml = HttpUtil.Post(new HttpItem()
            {

                URL = url,
                Method = "POST",
                ContentType = "text/xml",
                Data = data.ToXml(),
                X509Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate(Wechat_Config.SSlCertFilename, Wechat_Config.SSlCertPassword, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.PersistKeySet | System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.MachineKeySet)
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }

        /// <summary>
        /// 查询退款
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PayData RefundQuery(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/refundquery";

            #region 检测必填参数:
            if (!data.IsSet("out_refund_no") && !data.IsSet("out_trade_no") &&
                !data.IsSet("transaction_id") && !data.IsSet("refund_id"))
            {
                throw new Exception("退款查询接口中，out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个");
            }
            #endregion

            #region 添加必填参数:
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString());//随机字符串
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            //调用HTTP通信接口以提交数据到API
            string xml = HttpUtil.Post(new HttpItem()
            {
                URL = url,
                Method = "POST",
                ContentType = "text/xml",
                Data = data.ToXml(),
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }

        /// <summary>
        /// 下载对账单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PayData DownloadBill(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/downloadbill";

            #region 检测必填参数:
            if (!data.IsSet("bill_date"))
            {
                throw new Exception("对账单接口中，缺少必填参数:bill_date");
            }
            #endregion

            #region 添加必填参数:
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString("N"));//随机字符串
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            string xml = HttpUtil.Post(new HttpItem()
            {
                URL = url,
                Data = data.ToXml(),
                Method = "POST",
                ContentType = "text/xml",
            }).Document;
            PayData result = new PayData();
            if (xml.Substring(0, 5) == "<xml>")
            {
                result = PayData.FromXml(xml);
            }
            else
            {
                result.SetValue("result", xml);
            }
            #endregion

            return result;
        }

        /// <summary>
        /// 转换短链接
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PayData ShortUrl(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/tools/shorturl";

            #region 检测必填参数:
            if (!data.IsSet("long_url"))
            {
                throw new Exception("需要转换的URL，签名用原串，传输需URL encode");
            }
            #endregion

            #region 添加必填参数:
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString("N"));//随机字符串	
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            string xml = HttpUtil.Post(new HttpItem()
            {
                URL = url,
                Data = data.ToXml(),
                Method = "POST",
                ContentType = "text/xml",
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }

        /// <summary>
        /// 统一下单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PayData UnifiedOrder(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";

            #region 检测必填参数:
            if (!data.IsSet("out_trade_no"))
            {
                throw new Exception("缺少统一支付接口必填参数:out_trade_no");
            }
            else if (!data.IsSet("body"))
            {
                throw new Exception("缺少统一支付接口必填参数:body");
            }
            else if (!data.IsSet("total_fee"))
            {
                throw new Exception("缺少统一支付接口必填参数:total_fee");
            }
            else if (!data.IsSet("trade_type"))
            {
                throw new Exception("缺少统一支付接口必填参数:trade_type");
            }
            if (!data.IsSet("notify_url"))
            {
                throw new Exception("缺少统一支付接口必填参数:notify_url");
            }
            #endregion

            #region 关联参数检测
            if (data.GetValue("trade_type").ToString() == "JSAPI" && !data.IsSet("openid"))
            {
                throw new Exception("统一支付接口中，缺少必填参数:openidtrade_type为JSAPI时，openid为必填参数:");
            }
            if (data.GetValue("trade_type").ToString() == "NATIVE" && !data.IsSet("product_id"))
            {
                throw new Exception("统一支付接口中，缺少必填参数:product_idtrade_type为JSAPI时，product_id为必填参数:");
            }
            #endregion

            #region 设置必填参数
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("spbill_create_ip", Wechat_Config.MchIP);//终端ip	  	    
            data.SetValue("nonce_str", StringUtil.GetNonceStr());//随机字符串
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            string xml = HttpUtil.Post(new HttpItem()
            {
                URL = url,
                Data = data.ToXml(),
                Method = "POST",
                ContentType = "text/xml",
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="data"></param>

        /// <returns></returns>
        public static PayData CloseOrder(PayData data)
        {
            string url = "https://api.mch.weixin.qq.com/pay/closeorder";

            #region 检测必填参数:
            if (!data.IsSet("out_trade_no"))
            {
                throw new Exception("关闭订单接口中，out_trade_no必填");
            }
            #endregion

            #region 添加必填参数:
            data.SetValue("appid", Wechat_Config.AppID);//公众账号ID
            data.SetValue("mch_id", Wechat_Config.MchID);//商户号
            data.SetValue("nonce_str", Guid.NewGuid().ToString("N"));//随机字符串		
            data.SetValue("sign_type", Wechat_Config.SignType);//签名类型
            data.SetValue("sign", data.MakeSign());//签名
            #endregion

            #region 发起请求
            string xml = HttpUtil.Post(new HttpItem
            {
                URL = url,
                Data = data.ToXml(),
                Method = "POST",
                ContentType = "text/xml",
            }).Document;
            #endregion

            return PayData.FromXml(xml);
        }

        /// <summary>
        /// 获取jspay支付参数
        /// </summary>
        /// <param name="data"></param>
        public static PayData GetJsPayParam(PayData unifiedData)
        {
            var appData = new PayData();
            appData.SetValue("appId", unifiedData.GetValue("appid"));
            appData.SetValue("timeStamp", StringUtil.GetTimeStamp());
            appData.SetValue("nonceStr", StringUtil.GetNonceStr());
            appData.SetValue("package", "prepay_id=" + unifiedData.GetValue("prepay_id"));
            appData.SetValue("signType", Wechat_Config.SignType);
            appData.SetValue("sign", appData.MakeSign());
            return appData;
        }
        /// <summary>
        /// 获取支付通知数据包
        /// </summary>
        /// <returns></returns>
        public static PayData GetNotifyData(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                var xml = reader.ReadToEnd();
                return PayData.FromXml(xml);
            }
        }
        /// <summary>
        /// 通知处理成功
        /// </summary>
        public static string NotifySuccess = @"<xml><return_code><![CDATA[SUCCESS]]></return_code><return_msg><![CDATA[OK]]></return_msg></xml>";
        /// <summary>
        /// 通知处理失败
        /// </summary>
        public static string NotifyFail = @"<xml><return_code><![CDATA[FAIL]]></return_code></xml>";
        #endregion

    }

    /// <summary>
    /// 微信支付请求数据包
    /// </summary>
    public class PayData
    {
        private readonly SortedDictionary<string, object> Values = new SortedDictionary<string, object>();
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, object value)
        {
            Values[key] = value;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            Values.TryGetValue(key, out object o);
            return o;
        }

        /// <summary>
        /// 判断名为Key参数是否存在,并且不为null
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            Values.TryGetValue(key, out object o);
            if (null != o)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 将数据包转化成XML格式
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            //数据为空时不能转化为xml格式
            if (0 == Values.Count)
            {
                throw new Exception("数据包为空!");
            }
            StringBuilder xmlBuild = new StringBuilder("<xml>");
            foreach (KeyValuePair<string, object> pair in Values)
            {
                //字段值不能为null，会影响后续流程
                if (pair.Value == null)
                {
                    throw new Exception("数据包内部含有值为null的字段!");
                }
                if (pair.Value.GetType().IsValueType)
                {
                    xmlBuild.Append("<" + pair.Key + ">" + pair.Value.ToString() + "</" + pair.Key + ">");
                }
                else if (pair.Value.GetType() == typeof(string))
                {
                    xmlBuild.Append("<" + pair.Key + ">" + "<![CDATA[" + pair.Value.ToString() + "]]></" + pair.Key + ">");
                }
                else
                {   //除了string和数值类型不能含有其他数据类型
                    throw new Exception("请求参数中只能包含数字和字符类型的数据");
                }
            }
            xmlBuild.Append("</xml>");
            return xmlBuild.ToString();
        }

        /// <summary>
        /// 将xml转换成有序集合
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static PayData FromXml(string xml)
        {
            PayData payData = new PayData();
            if (string.IsNullOrEmpty(xml))
            {
                throw new Exception("将空的xml串转换为数据包不合法!");
            }
            XmlDocument xmlDoc = new XmlDocument
            {
                XmlResolver = null
            };
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                payData.SetValue(xe.Name, xe.InnerText);
            }

            //2015-06-29 错误是没有签名
            if (!"SUCCESS".Equals(payData.GetValue("return_code")))
            {
                return payData;
            }
            payData.CheckSign();//验证签名,不通过会抛异常

            return payData;
        }

        /// <summary>
        /// 将数据包转化成url参数
        /// </summary>
        /// <returns></returns>
        public string ToUrl()
        {
            StringBuilder buff = new StringBuilder();
            foreach (KeyValuePair<string, object> pair in Values)
            {
                if (pair.Value == null)
                {
                    throw new Exception("数据包内部含有值为null的字段!");
                }
                if (pair.Key != "sign" && pair.Value.ToString() != "")
                {
                    buff.Append(pair.Key + "=" + pair.Value + "&");
                }
            }
            return buff.ToString().Trim('&');
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <returns></returns>
        public string MakeSign()
        {
            //转url格式,在string后加入API KEY
            string url = ToUrl() + "&key=" + Wechat_Config.Key;
            if (Wechat_Config.SignType == "MD5")
            {
                return StringUtil.GetMD532Bit(url);
            }
            else if (Wechat_Config.SignType == "HMAC-SHA256")
            {
                return StringUtil.GetSHA256(url);
            }
            else
            {
                throw new Exception("sign_type 不合法");
            }
        }

        /// <summary>
        /// 检测数据包签名是否正确
        /// </summary>
        /// <returns></returns>
        public bool CheckSign()
        {
            //如果没有设置签名，则跳过检测
            if (!IsSet("sign"))
            {
                throw new Exception("数据包签名不存在!");
            }
            //如果设置了签名但是签名为空，则抛异常
            else if (GetValue("sign") == null || GetValue("sign").ToString() == "")
            {
                throw new Exception("数据包签名存在但不合法!");
            }
            //获取接收到的签名
            string return_sign = GetValue("sign").ToString();
            //在本地计算新的签名
            string new_sign = MakeSign();
            if (new_sign == return_sign)
            {
                return true;
            }
            throw new Exception("数据包签名验证错误!");
        }

        /// <summary>
        /// 获取数据包
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, object> GetValues()
        {
            return Values;
        }
    }

}