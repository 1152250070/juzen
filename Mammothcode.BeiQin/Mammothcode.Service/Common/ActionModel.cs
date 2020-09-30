using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mammothcode.Service
{
    public interface IResult
    {
        bool Result { get; set; }
        int Status { get; set; }
    }
    public class OkResult : IResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }
    public class ExceptionResult : IResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Exception { get; set; }
        public int Status { get; set; }
    }
    public class DataResult<T> : IResult
    {
        public bool Result { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
    }
    public class DataMessageResult<T> : IResult
    {
        public bool Result { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
    public class PageDatalResult<T> : IResult
    {
        public int Status { get; set; }
        public bool Result { get; set; }
        public IEnumerable<T> Data { get; set; }
        public long Total { get; set; }
    }
    public interface IActionModel : IResult
    {
        string ToJson();
    }
    /// <summary>
    /// 返回数据
    /// </summary>
    public class ActionModel : IActionModel
    {
        public int Status { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public string ErrMsg { get; set; }
        public string ToJson()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                Converters =
                {
                    //日期处理
                    new IsoDateTimeConverter()
                     {
                        DateTimeFormat= "yyyy-MM-dd HH:mm:ss"
                     }
                },
                //Camel命名:首字母小写
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            return JsonConvert.SerializeObject(this, serializerSettings);
        }
        /// <summary>
        /// 返回的总数量
        /// </summary>
        public long Total { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; }
        public ActionModel()
        {

        }
        public ActionModel(bool result)
        {
            Status = result ? 0 : -1;
            Result = result;
            Message = "success";
        }
        public ActionModel(object data, long total = 0) : this(true)
        {
            Data = data;
            Total = total;
        }
    }
}