using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
namespace SignalRWebUI.Controllers
{

    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id; // Burada MenuTableId değerini ayarlıyoruz
                            // TempData["x"] = id; // Eğer bunu kullanıyorsanız

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5247/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int menuTableId)
        {
            if (menuTableId == 0)
                return BadRequest("MenuTableId 0 geliyor.");

            var dto = new CreateBasketDto { ProductID = id, MenuTableID = menuTableId };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            // 1) Ürünü sepete ekle
            var addResp = await client.PostAsync("http://localhost:5247/api/Basket", content);
            if (!addResp.IsSuccessStatusCode)
                return StatusCode((int)addResp.StatusCode, await addResp.Content.ReadAsStringAsync());

            // 2) Masa durumunu API'den değiştir (true = dolu)
            var putUrl = $"http://localhost:5247/api/MenuTable/ChangeMenuTableStatus/{menuTableId}?status=true";
            var putResp = await client.PutAsync(putUrl, null as HttpContent); // body yok, query ile gidiyor
                                                                              // putResp başarısız ise istersen logla ama kullanıcıyı bekletme

            // 3) Aynı masanın menü sayfasına dön
            return RedirectToAction("Index", new { id = menuTableId });
        }


    }


}
