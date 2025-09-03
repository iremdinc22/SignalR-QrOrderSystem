using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.TestimonialDtos;

namespace ViewComponents.LayoutComponents
{
    public class DefaultTestimonialPartialViewComponent : ViewComponent
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultTestimonialPartialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5247/api/Testimonial");

            List<ResultTestimonialDto> values = new List<ResultTestimonialDto>();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            }

            return View(values);
        }
     }
    }
