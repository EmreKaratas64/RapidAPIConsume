using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_WEBUI.DTOs.ServiceDtos;
using System.Text;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListServices()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(AddServiceDto addServiceDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(addServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5291/api/Service", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListServices");
                }
            }
            return View(addServiceDto);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5291/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListServices");
            }
            return RedirectToAction("ListServices");
        }

        [HttpGet]
        public async Task<IActionResult> GetService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5291/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetService(UpdateServiceDto updateServiceDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5291/api/Service/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListServices");
                }
            }
            return View(updateServiceDto);
        }
    }
}
