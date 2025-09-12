using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ZXing;
using ZXing.Common;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Png;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        // GET: QR Oluşturma sayfası
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: QR Oluşturma işlemi
        [HttpPost]
        public IActionResult Index(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return View();

            using var generator = new QRCodeGenerator();
            using QRCodeData data = generator.CreateQrCode(value, QRCodeGenerator.ECCLevel.H);

            // System.Drawing yok → Base64 ile üret
            var base64 = new Base64QRCode(data).GetGraphic(10);
            ViewBag.QrCodeImage = "data:image/png;base64," + base64;

            return View();
        }

        // GET: QR Kod çözümleme sayfası
        [HttpGet]
        public IActionResult Decode()
        {
            return View();
        }

        // POST: QR Kod çözümleme işlemi
        [HttpPost]
        public async Task<IActionResult> Decode(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "Lütfen bir QR görseli yükleyin.";
                return View();
            }

            using var stream = file.OpenReadStream();
            using var image = await SixLabors.ImageSharp.Image.LoadAsync<Rgba32>(stream);

            // 1) ImageSharp -> RGBA piksel verisini al
            int width = image.Width;
            int height = image.Height;
            var pixels = new byte[width * height * 4]; // RGBA (4 kanal)
            image.CopyPixelDataTo(pixels);

            // 2) ZXing'e uygun luminance source oluştur
            var luminance = new ZXing.RGBLuminanceSource(
                pixels, width, height, RGBLuminanceSource.BitmapFormat.RGBA32);

            var binarizer = new HybridBinarizer(luminance);
            var binaryBitmap = new BinaryBitmap(binarizer);

            // 3) ZXing MultiFormatReader ile decode et
            var reader = new ZXing.MultiFormatReader();
            var result = reader.decode(binaryBitmap);

            ViewBag.Decoded = result?.Text;
            ViewBag.Success = result != null;

            // Yüklenen görseli base64 olarak view'a gönder
            using var previewMs = new MemoryStream();
            await image.SaveAsync(previewMs, new PngEncoder());
            ViewBag.UploadedImageBase64 = "data:image/png;base64," +
                                          Convert.ToBase64String(previewMs.ToArray());

            return View();
        }

    }
}
