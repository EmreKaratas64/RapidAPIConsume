using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class HomePageTestimonials : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomePageTestimonials(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessasge = await client.GetAsync("http://localhost:5291/api/Testimonial");
            if (responseMessasge.IsSuccessStatusCode)
            {
                var jsonData = await responseMessasge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Testimonial>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
