using Microsoft.AspNetCore.Mvc;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> DashboardPage()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5291/api/Guest/CountGuests");
            ViewBag.GuestNumber = await response.Content.ReadAsStringAsync();
            return View();
        }
    }
}
