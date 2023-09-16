using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.ViewModels;
using FrontToBack_PartialView_LoadMore.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new();
            appUser.FullName = registerVM.Fullname;
            appUser.UserName = registerVM.Username;
            appUser.Email = registerVM.Email;
            IdentityResult result=await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                return View(registerVM);
            }
            return RedirectToAction("index","Home");
        }
    }
}
