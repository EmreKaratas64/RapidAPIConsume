using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class HomePageServices : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomePageServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessasge = await client.GetAsync("http://localhost:5291/api/Service");
            if (responseMessasge.IsSuccessStatusCode)
            {
                var jsonData = await responseMessasge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Service>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
