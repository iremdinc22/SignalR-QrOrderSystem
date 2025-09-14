using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.RapidApiDtos;

namespace SignalRWebUI.Controllers
{
    public class FoodRapidApiController : Controller
    {
        private readonly IConfiguration _config;

        public FoodRapidApiController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Get,
                "https://tasty.p.rapidapi.com/recipes/list?from=0&size=30&tags=under_30_minutes");

            req.Headers.Add("x-rapidapi-key", _config["RapidApi:TastyKey"]);
            req.Headers.Add("x-rapidapi-host", _config["RapidApi:TastyHost"]);

            var resp = await client.SendAsync(req);
            var body = await resp.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<TastyListResponse>(body);
            var values = root.Results;
            return View(values.ToList());
        }
    }
}
