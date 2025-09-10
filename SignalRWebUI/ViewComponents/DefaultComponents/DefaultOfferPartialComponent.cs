using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;

namespace ViewComponents.DefaultComponents
{
    public class DefaultOfferPartialViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultOfferPartialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.GetAsync("http://localhost:5247/api/Discount/GetActiveDiscounts");
            var json = await resp.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(json) ?? new List<ResultDiscountDto>();
            return View(values); // Views/Shared/Components/DefaultOfferPartial/Default.cshtml
        }


    }
}