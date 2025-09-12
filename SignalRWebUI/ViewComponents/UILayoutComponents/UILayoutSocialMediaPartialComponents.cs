using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace ViewComponents.UILayoutComponents
{
    public class UILayoutSocialMediaPartialViewComponent : ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;
        public UILayoutSocialMediaPartialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5247/api/SocialMedia");

            List<ResultSocialMediaDto> values = new List<ResultSocialMediaDto>();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            }

            return View(values);
        }
    }
}