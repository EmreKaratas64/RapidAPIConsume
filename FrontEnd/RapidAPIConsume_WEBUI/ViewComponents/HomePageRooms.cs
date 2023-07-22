using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class HomePageRooms : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomePageRooms(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Room>>(jsonData).Take(3).ToList();
                return View(values);
            }
            return View();
        }
    }
}
