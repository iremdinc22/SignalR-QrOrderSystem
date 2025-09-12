using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User?.Identity?.Name == null)
                return Challenge(); // kullanıcı giriş yapmamışsa

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            var dto = new UserEditDto
            {
                Name = user.UserName,              // AppUser'da özel alanların varsa burada doldur
                Surname = user.NormalizedUserName, // örnek: user.Surname
                Mail = user.Email,
                Username = user.UserName,
                // PasswordHash'ı asla view'e göndermeyiz!
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto dto)
        {
            if (dto.Password == dto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null) return NotFound();

                user.Name = dto.Name;
                user.Surname = dto.Surname;
                user.Email = dto.Mail;
                user.UserName = dto.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);

                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Category");
            }
            return View(dto);
        }


    }



}
