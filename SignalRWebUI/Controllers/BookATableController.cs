using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.BookingDtos;
namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5247/api/Contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.Location = value;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            // İletişim bilgisini çek (varsa UI'da gösteriyorsun)
            using var client2 = _httpClientFactory.CreateClient(); // aynı factory'yi kullanalım
            var response = await client2.GetAsync("http://localhost:5247/api/Contact");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var item = JArray.Parse(responseBody);
            ViewBag.Location = item[0]?["location"]?.ToString();

            // Her rezervasyona otomatik açıklama
            createBookingDto.Description = "b";

            // Tarihi UTC'ye çevir (Npgsql timestamptz için gerekli)
            if (createBookingDto.Date != default)
            {
                var dt = createBookingDto.Date;
                if (dt.Kind == DateTimeKind.Unspecified)
                {
                    var tz = TimeZoneInfo.FindSystemTimeZoneById("Europe/Istanbul");
                    createBookingDto.Date = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(dt, DateTimeKind.Unspecified), tz);
                }
                else if (dt.Kind == DateTimeKind.Local)
                {
                    createBookingDto.Date = dt.ToUniversalTime();
                }
                // Kind zaten Utc ise dokunma
            }

            // Rezervasyonu oluştur
            using var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5247/api/Booking", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Default");

            return View(createBookingDto);
        }




    }
}