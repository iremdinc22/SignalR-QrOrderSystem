using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{

    // Autorizasyon gerektirmeyen controllerda kullanılan ifade
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        // Constructor injection
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginDto.Username,
                loginDto.Password,
                false,
                false);


            if (result.Succeeded)
            {
                // Başarılı giriş → Anasayfaya yönlendir
                return RedirectToAction("Index", "Category");
            }

            // Başarısız giriş → Hata göster
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            return View(loginDto);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
