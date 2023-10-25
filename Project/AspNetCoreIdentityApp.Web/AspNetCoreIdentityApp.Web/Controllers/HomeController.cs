using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspNetCoreIdentityApp.Web.Extensions;
using NuGet.Common;
using AspNetCoreIdentityApp.Web.Services;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl = null)
        {
            returnUrl ??= Url.Action("Index", "Home");

            var hasUser = await _userManager.FindByEmailAsync(email: request.Email!);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, password: request.Password!, request.RememberMe, true);


            if (signInResult.Succeeded)
            {
                return Redirect(url: returnUrl!);

            }
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "3 dakika boyunca giriş yapamazsınız." });
                return View();
            }

            ModelState.AddModelErrorList(new List<string>() { "Email veya şifreniz yanlış.", $"(Başarısız Giriş Sayısı: {await _userManager.GetAccessFailedCountAsync(hasUser)})" });

            return View();

        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            var hasUser = await _userManager.FindByEmailAsync(request.Email!);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Bu mail adresine sahip kullanıcı bulunamamıştır.");
                return View();
            }

            string passwordResetsToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);
            var passwordResetLink = Url.Action("ResetPassword", "Home", new { userId = hasUser.Id, Token = passwordResetsToken }, HttpContext.Request.Scheme);


            //link
            // https://localhost:7013?userId&token=asdasfbfa

            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email!);

            //Email Service
            TempData["SuccessMessage"] = "Şifre Yenileme Linki Eposta Adresinize Gönderilmiştir.";


            return RedirectToAction(nameof(ForgetPassword));
        }

        public  IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];
            if(userId==null || token == null)
            {
                throw new Exception("Bir hata meydana geldi.");
            }
            var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Böyle bir kullanıcı bulunamamıştır."); 
                return View();
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password!);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Şifreniz başarıyla yenilenmiştir.";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
                return View();
            }
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
                return View();
            }
            if (_userManager.Users.Any(u => u.PhoneNumber == request.Phone))
            {
                ModelState.AddModelError(string.Empty, "Bu telefon numarası zaten kullanılıyor.");
                return View(request);
            }
            var identityResult = await _userManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, password: request.PasswordConfirm!);
            if (identityResult.Succeeded)
            {

                TempData["SuccessMessage"] = "Üyelik İşlemi Başarıyla Gerçekleşmiştir.";

                return RedirectToAction(nameof(HomeController.SignUp));
            }

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
            return View(request);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}