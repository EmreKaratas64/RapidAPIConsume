using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_WEBUI.ViewComponents
{

    public class DashboardLast4Staff : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardLast4Staff(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/Staff/Last4StaffList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Staff>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
