using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.DTOs.BookingAPIDtos;
using RapidAPIConsume_WEBUI.DTOs.BookingDtos;
using System.Text;

namespace RapidAPIConsume_WEBUI.Controllers
{

    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult AddBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingDto addBookingDto)
        {
            addBookingDto.Status = BookingStatus.Bekleniyor;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5291/api/Booking", content);
            return RedirectToAction("HomePage", "Home");
        }

        public async Task<IActionResult> ListBookings()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Booking>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApproveReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5291/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Booking>(jsonData);
                value.Status = BookingStatus.Onaylandı;
                var serializedValue = JsonConvert.SerializeObject(value);
                StringContent serializedValueContent = new StringContent(serializedValue, Encoding.UTF8, "application/json");
                var updateResponse = await client.PutAsync("http://localhost:5291/api/Booking/", serializedValueContent);

                return RedirectToAction("ListBookings");
            }
            else
                return NotFound();
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5291/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Booking>(jsonData);
                value.Status = BookingStatus.IptalEdildi;
                var serializedValue = JsonConvert.SerializeObject(value);
                StringContent serializedValueContent = new StringContent(serializedValue, Encoding.UTF8, "application/json");
                var updateResponse = await client.PutAsync("http://localhost:5291/api/Booking/", serializedValueContent);

                return RedirectToAction("ListBookings");
            }
            else
                return NotFound();
        }

        public IActionResult FindBookingAPIDestID()
        {
            return View();
        }

        public async Task<IActionResult> BringDestID(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3afe765c37msh2846d271b23bb13p140d30jsn9923964c3065" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var dest_id = JsonConvert.DeserializeObject<List<BookingAPIDestId>>(body);
                    dest_id = dest_id.Take(1).ToList();
                    var jsonDestId = JsonConvert.SerializeObject(dest_id);
                    return Json(jsonDestId);
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name=poznan&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3afe765c37msh2846d271b23bb13p140d30jsn9923964c3065" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var dest_id = JsonConvert.DeserializeObject<List<BookingAPIDestId>>(body);
                    dest_id = dest_id.Take(1).ToList();
                    var jsonDestId = JsonConvert.SerializeObject(dest_id);
                    return Json(jsonDestId);
                }
            }

        }

        public async Task<IActionResult> BookingAPI(string cityId)
        {
            if (!string.IsNullOrEmpty(cityId))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=EUR&dest_id={cityId}&locale=en-gb&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&children_number=2&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3afe765c37msh2846d271b23bb13p140d30jsn9923964c3065" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var hotels = JsonConvert.DeserializeObject<BookingAPIResults>(body);
                    return View(hotels.results.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=EUR&dest_id=-523642&locale=en-gb&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&children_number=2&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3afe765c37msh2846d271b23bb13p140d30jsn9923964c3065" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var hotels = JsonConvert.DeserializeObject<BookingAPIResults>(body);
                    return View(hotels.results.ToList());
                }
            }
        }
    }
}
