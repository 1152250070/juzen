//using QRCoder;
//using System.Drawing;
//using static QRCoder.PayloadGenerator;

//namespace Common.Library.File
//{
//    public class QrCodeUtil
//    {
//        /// <summary>
//        /// 创建普通文本二维码
//        /// </summary>
//        /// <param name="text"></param>
//        public static Bitmap Text(string text, Image icon = null)
//        {
//            QRCodeGenerator qrGenerator = new QRCodeGenerator();
//            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.H);
//            QRCode qrCode = new QRCode(qrCodeData);
//            Bitmap qrCodeImage = icon == null ? qrCode.GetGraphic(20) : qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)icon);
//            return qrCodeImage;
//        }
//        /// <summary>
//        /// URL跳转二维码
//        /// </summary>
//        public static Bitmap URL(string url, Image icon = null)
//        {
//            var payload = new Url(url);
//            QRCodeGenerator qrGenerator = new QRCodeGenerator();
//            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload.ToString(), QRCodeGenerator.ECCLevel.H);
//            QRCode qrCode = new QRCode(qrCodeData);
//            Bitmap qrCodeImage = icon == null ? qrCode.GetGraphic(20) : qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)icon);
//            return qrCodeImage;
//        }
//        /// <summary>
//        /// 扫一扫连接二维码
//        /// </summary>
//        public static Bitmap WiFi(string name, string password, Image icon = null)
//        {
//            var payload = new WiFi(name, password, PayloadGenerator.WiFi.Authentication.WPA, false);
//            QRCodeGenerator qrGenerator = new QRCodeGenerator();
//            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload.ToString(), QRCodeGenerator.ECCLevel.H);
//            QRCode qrCode = new QRCode(qrCodeData);
//            Bitmap qrCodeImage = icon == null ? qrCode.GetGraphic(20) : qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)icon);
//            return qrCodeImage;
//        }
//    }
//}
