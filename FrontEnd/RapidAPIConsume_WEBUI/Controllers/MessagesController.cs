using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.Models;
using System.Text;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        MyMailService mailService = new MyMailService();

        public MessagesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ContactMessages()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> SendMessages()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SendMessage>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(SendMessage sendMessage)
        {
            sendMessage.Date = DateTime.Now;
            sendMessage.SenderMail = "admin@gmail.com";
            sendMessage.SenderName = "admin";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(sendMessage);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5291/api/SendMessage", content);
            if (response.IsSuccessStatusCode)
            {
                mailService.SendMail(sendMessage.ReceiverMail, "HotelAPI " + sendMessage.Title, sendMessage.Content);
                return RedirectToAction("SendMessages");
            }


            return View(sendMessage);
        }



        public async Task<IActionResult> ContactMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5291/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Contact>(jsonData);
                return View(value);
            }
            return View();
        }

        public async Task<IActionResult> SendMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5291/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SendMessage>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
