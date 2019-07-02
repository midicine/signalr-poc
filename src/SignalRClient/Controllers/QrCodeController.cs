using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.IO;

namespace SignalRClient.Controllers
{
    public class QrCodeController : Controller
    {
        public IActionResult Index()
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode($"{Guid.Empty}", QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            using (var stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.DrawingCore.Imaging.ImageFormat.Jpeg);
                return File(stream.ToArray(), "image/jpeg");
            }
        }
    }
}