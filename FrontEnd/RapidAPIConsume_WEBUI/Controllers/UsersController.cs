using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.DTOs.AppUserDtos;
using RapidAPIConsume_WEBUI.DTOs.RoleDtos;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UsersController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _roleManager = roleManager;
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

        [HttpGet]
        public async Task<IActionResult> AssignRole(int Id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == Id);
            TempData["UserId"] = Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignDto> roleAssignDto = new List<RoleAssignDto>();
            foreach (var role in roles)
            {
                RoleAssignDto model = new RoleAssignDto();
                model.RoleId = role.Id;
                model.RoleName = role.Name;
                model.RoleExists = userRoles.Contains(role.Name);
                roleAssignDto.Add(model);
            }
            return View(roleAssignDto);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignDto> roleAssignDto)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in roleAssignDto)
            {
                if (item.RoleExists)
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
            }

            return RedirectToAction("ListUsers");
        }

    }
}
