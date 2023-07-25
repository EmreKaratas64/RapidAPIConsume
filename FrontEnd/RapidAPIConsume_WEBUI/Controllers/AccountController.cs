using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.DTOs.AccountDtos;
using RapidAPIConsume_WEBUI.Models;

namespace RapidAPIConsume_WEBUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        MyMailService mailService = new MyMailService();
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = registerDto.Mail,
                    UserName = registerDto.Mail,
                    WorkLocationID = 1
                };
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    mailService.SendMail(registerDto.Mail, "HotelAPI hesap onay", "Tebrikler HotelAPI hesabınız başarıyla oluşturuldu\n\nHesap onay kodunuz: buraya hesap onay kodu gelecek!!");
                    return RedirectToAction("ListStaffs", "Staff");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerDto);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Mail);
                if (user == null) return NotFound();
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginDto.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("ListStaffs", "Staff");
            }
            return View(loginDto);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
