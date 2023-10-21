using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
        

            if (!ModelState.IsValid)
            {
                return  View();
            }
            if (_userManager.Users.Any(u => u.PhoneNumber == request.Phone))
            {
                ModelState.AddModelError(string.Empty, "Bu telefon numarası zaten kullanılıyor.");
                return View(request);
            }
            #pragma warning disable CS8604 // Possible null reference argument.  Hataları göstermemesi için
            var identityResult = await _userManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, password: request.PasswordConfirm);
            #pragma warning restore CS8604 // Possible null reference argument.  Hataları göstermemesi için
            if (identityResult.Succeeded)
            {

                TempData["SuccessMessage"] = "Üyelik İşlemi Başarıyla Gerçekleşmiştir.";

                return RedirectToAction(nameof(HomeController.SignUp));
            }

            foreach (IdentityError item in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(request);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}