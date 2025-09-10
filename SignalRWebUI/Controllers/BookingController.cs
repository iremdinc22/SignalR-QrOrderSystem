using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.BookingDtos;
using System.Net.Http.Json;
using System.Text.Json;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5247/api/Booking");

            List<ResultBookingDto>? values = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                values = JsonSerializer.Deserialize<List<ResultBookingDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı.";
            var client = _httpClientFactory.CreateClient();

            // datetime-local veya type="date" -> Unspecified gelir. Local varsay -> UTC'ye çevir
            var local = DateTime.SpecifyKind(createBookingDto.Date, DateTimeKind.Local);
            createBookingDto.Date = local.ToUniversalTime();

            // Giden payloadı logla
            Console.WriteLine("[WebUI] -> POST /api/Booking payload(UTC): " +
                              JsonSerializer.Serialize(createBookingDto));

            HttpResponseMessage res;
            try
            {
                res = await client.PostAsJsonAsync("http://localhost:5247/api/Booking", createBookingDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WebUI] POST /api/Booking exception: {ex}");
                ModelState.AddModelError("", $"API çağrısı başarısız: {ex.Message}");
                return View(createBookingDto);
            }

            var body = await res.Content.ReadAsStringAsync();
            Console.WriteLine($"[WebUI] <- POST /api/Booking status: {(int)res.StatusCode} {res.ReasonPhrase}");
            Console.WriteLine($"[WebUI] <- Body: {body}");

            if (!res.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", $"POST /api/Booking başarısız: {(int)res.StatusCode} - {body}");
                return View(createBookingDto);
            }

            TempData["ok"] = "Rezervasyon oluşturuldu.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.DeleteAsync($"http://localhost:5247/api/Booking/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            var body = await res.Content.ReadAsStringAsync();
            ModelState.AddModelError("", $"Silme işlemi başarısız: {(int)res.StatusCode} - {body}");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync($"http://localhost:5247/api/Booking/{id}");

            if (res.IsSuccessStatusCode)
            {
                var json = await res.Content.ReadAsStringAsync();
                var values = JsonSerializer.Deserialize<UpdateBookingDto>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(values);
            }

            ModelState.AddModelError("", $"Kayıt getirilemedi: {(int)res.StatusCode}");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            updateBookingDto.Description = "Rezervasyon Alındı.";
            var client = _httpClientFactory.CreateClient();

            // Unspecified -> Local -> UTC
            var local = DateTime.SpecifyKind(updateBookingDto.Date, DateTimeKind.Local);
            updateBookingDto.Date = local.ToUniversalTime();

            Console.WriteLine("[WebUI] -> PUT /api/Booking payload(UTC): " +
                              JsonSerializer.Serialize(updateBookingDto));

            HttpResponseMessage res;
            try
            {
                res = await client.PutAsJsonAsync("http://localhost:5247/api/Booking", updateBookingDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WebUI] PUT /api/Booking exception: {ex}");
                ModelState.AddModelError("", $"API çağrısı başarısız: {ex.Message}");
                return View(updateBookingDto);
            }

            var body = await res.Content.ReadAsStringAsync();
            Console.WriteLine($"[WebUI] <- PUT /api/Booking status: {(int)res.StatusCode} {res.ReasonPhrase}");
            Console.WriteLine($"[WebUI] <- Body: {body}");

            if (!res.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", $"PUT /api/Booking başarısız: {(int)res.StatusCode} - {body}");
                return View(updateBookingDto);
            }

            TempData["ok"] = "Rezervasyon güncellendi.";
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> BookingStatusApproved(int id)
        {

            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5247/api/Booking/BookingStatusApproved/{id}");
            return RedirectToAction("Index");
        }

      
        public async Task<IActionResult> BookingStatusCancelled(int id)
        {

            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5247/api/Booking/BookingStatusCancelled/{id}");
            return RedirectToAction("Index");
        }

    }
}
