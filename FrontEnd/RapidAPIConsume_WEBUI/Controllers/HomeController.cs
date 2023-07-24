using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;
using System.Text;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public PartialViewResult CustomerLayoutHeader()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutHeaderInBody()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutFooter()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutScripts()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutSubscribePartialView()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(Subscribe subscribe)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(subscribe);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5291/api/Subscribe", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonSubscribe = jsonData;
                return Json(jsonSubscribe);
            }
            return RedirectToAction("HomePage", "Home");

        }

        public IActionResult ContactMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContactMessage(Contact contact)
        {
            contact.Date = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://localhost:5291/api/Contact", content);
            if (result.IsSuccessStatusCode)
            {
                //var jsonContact = jsonData;
                return Json(jsonData);
            }
            return RedirectToAction("ContactMessage");
        }
    }
}
