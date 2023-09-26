using Memory.Business.Abstract;
using Memory.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace Memory.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Notebook");
            }
            ModelState.AddModelError("", "Kullanıcı Adı veya Parola Hatalı!");
            return View(loginDto);
        }
        [HttpGet]
        public IActionResult Register() 
        {
           //""
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _authService.Logout();
            return RedirectToAction("Login");
        }
    }
}
