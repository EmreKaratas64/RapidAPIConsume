using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.DTOs.BookingDtos;
using System.Text;

namespace RapidAPIConsume_WEBUI.Controllers
{

    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public BookingController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingDto addBookingDto)
        {
            addBookingDto.Status = "Yok";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5291/api/Booking", content);
            return RedirectToAction("HomePage", "Home");
        }
    }
}
