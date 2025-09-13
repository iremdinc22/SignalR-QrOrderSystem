using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;

namespace ViewComponents.MenuComponents
{
    public class MenuCategoryFilterPartialViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuCategoryFilterPartialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMessage = await client.GetAsync("http://localhost:5247/api/Category");

            var values = new List<ResultCategoryDto>();      // <-- null yerine boş liste

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData)
                         ?? new List<ResultCategoryDto>();   // <-- null-coalesce
            }

            return View(values);
        }
    }
}

