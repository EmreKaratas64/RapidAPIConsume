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
            var clients = await client.GetAsync("http://localhost:5291/api/Guest/CountGuests");
            ViewBag.Guests = await clients.Content.ReadAsStringAsync();

            var staffs = await client.GetAsync("http://localhost:5291/api/Staff/GetStaffCount");
            ViewBag.Staffs = await staffs.Content.ReadAsStringAsync();

            var bookings = await client.GetAsync("http://localhost:5291/api/Booking/GetBookingCount");
            ViewBag.Bookings = await bookings.Content.ReadAsStringAsync();

            var rooms = await client.GetAsync("http://localhost:5291/api/Room/GetRoomCount");
            ViewBag.Rooms = await rooms.Content.ReadAsStringAsync();
            return View();
        }
    }
}
