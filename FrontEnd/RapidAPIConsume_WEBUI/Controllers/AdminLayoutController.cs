using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_WEBUI.DTOs.CurrencyDtos;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
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
