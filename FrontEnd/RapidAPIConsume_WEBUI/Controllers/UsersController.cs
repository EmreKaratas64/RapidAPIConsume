﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_WEBUI.DTOs.AppUserDtos;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListUsers()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5291/api/AppUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListAppUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
