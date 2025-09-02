
using Microsoft.AspNetCore.Mvc;
namespace SignalRWebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRDefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}