using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class AdminMailLeftBox : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMailLeftBox(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5291/api/Contact");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                ViewBag.InBoxCount = JsonConvert.DeserializeObject<List<Contact>>(jsonData).Count;
            }

            return View();
        }
    }
}
