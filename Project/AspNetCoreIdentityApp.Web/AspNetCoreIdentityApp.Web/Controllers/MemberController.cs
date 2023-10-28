using AspNetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

      
        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser =await _userManager.FindByNameAsync(User.Identity!.Name!);
           var userViewModel = new ViewModels.UserViewModel
            {
                Email = currentUser!.Email,
                UserName = currentUser.UserName,
                PhoneNumber = currentUser.PhoneNumber,
            };
            return View(userViewModel);
        }
     
        public async Task LogOut()
        {
          await  _signInManager.SignOutAsync();
        }
    }
}
