using Microsoft.AspNetCore.Mvc;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class AdminDashboardCards : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardCards(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5291/api/Guest/CountGuests");
            ViewBag.GuestNumber = await response.Content.ReadAsStringAsync();
            return View();
        }
    }
}
