using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.DTOs.AboutDtos;
using RapidAPIConsume_WEBUI.DTOs.CurrencyDtos;
using System.Text;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Layout()
        {
            return View();
        }

        public async Task<IActionResult> AboutAdmin()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<UpdateAboutDto>>(jsonData);
                var about = value.TakeLast(1).FirstOrDefault();
                return View(about);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAboutAdmin(UpdateAboutDto updateAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var about = await client.GetAsync($"http://localhost:5291/api/About/{updateAboutDto.AboutID}");
            var jsonData = await about.Content.ReadAsStringAsync();
            var deserializeAbout = JsonConvert.DeserializeObject<About>(jsonData);
            deserializeAbout.Title1 = updateAboutDto.Title1;
            deserializeAbout.Title2 = updateAboutDto.Title2;
            deserializeAbout.Content = updateAboutDto.Content;
            var serializeAbout = JsonConvert.SerializeObject(deserializeAbout);
            StringContent content = new StringContent(serializeAbout, Encoding.UTF8, "application/json");
            await client.PutAsync("http://localhost:5291/api/About", content);
            return Json(serializeAbout);

        }

        public PartialViewResult AdminHeader()
        {
            return PartialView();
        }

        public PartialViewResult AdminNavHeader()
        {
            return PartialView();
        }

        public PartialViewResult AdminSideBar()
        {
            return PartialView();
        }

        public PartialViewResult AdminFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminScripts()
        {
            return PartialView();
        }

        public async Task<IActionResult> APICurrencies()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
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
                var currencies = JsonConvert.DeserializeObject<CurrencyResult>(body);
                return View(currencies.exchange_rates.ToList());
            }
        }

    }
}
