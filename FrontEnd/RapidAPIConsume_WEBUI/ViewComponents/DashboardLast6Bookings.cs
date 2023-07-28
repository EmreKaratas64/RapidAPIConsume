using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class DashboardLast6Bookings : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardLast6Bookings(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/Booking/Last6BookingList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Booking>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
