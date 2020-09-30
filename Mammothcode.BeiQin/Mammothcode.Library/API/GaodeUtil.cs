using Mammothcode.Library.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammothcode.Library.API
{
    /// <summary>
    /// 高德地图
    /// </summary>
    public class GaodeUtil
    {
        private static string _key = "8325164e247e15eea68b59e89200988b";
        /// <summary>
        /// 通过地址获取经纬度
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetLocation(string address)
        {
            var url = string.Format("http://restapi.amap.com/v3/place/text?s=rsv3&children=&key={0}&page=1&offset=1&language=zh_cn&platform=JS&logversion=2.0&sdkversion=1.3&appname=http://lbs.amap.com/console/show/picker&csid=DEDE1BA4-5C50-4A86-A50B-A497842075AE&keywords={1}", _key, address);
            return HttpUtil.Post(new HttpItem()
            {
                URL = url
            }).Document;
        }
        /// <summary>
        /// 通过经纬度获得地址
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static string GetAddress(double lng, double lat)
        {
            var url = string.Format("https://restapi.amap.com/v3/geocode/regeo?key={0}&s=rsv3&location={1},{2}&radius=2800&platform=JS&logversion=2.0&sdkversion=1.3&appname=https://lbs.amap.com/console/show/picker&csid=146CF35A-662C-4F91-8757-F7B253E00446", _key, lng, lat);
            return HttpUtil.Post(new HttpItem()
            {
                URL = url
            }).Document;
        }
        /// <summary>
        /// 计算两点直接的距离
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = lat1 * Math.PI / 180d;
            double radLng1 = lng1 * Math.PI / 180d;
            double radLat2 = lat2 * Math.PI / 180d;
            double radLng2 = lng2 * Math.PI / 180d;
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2d * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2d), 2d) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2d), 2d))) * 6378137d;
            return result;
        }
    }
}
