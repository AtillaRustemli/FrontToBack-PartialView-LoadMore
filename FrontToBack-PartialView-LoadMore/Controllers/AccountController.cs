using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.ViewModels;
using FrontToBack_PartialView_LoadMore.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        //Register

        public IActionResult Registers()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registers(RegisterVM registerVM)
        {
            var role =await _roleManager.FindByNameAsync("Member");
            if(!ModelState.IsValid) return View();
            AppUser appUser = new();
            appUser.FullName = registerVM.Fullname;
            appUser.UserName = registerVM.Username;
            appUser.Email = registerVM.Email;
            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description.ToString());
                }
                return View(registerVM);
            }
            await _userManager.AddToRoleAsync(appUser, role.ToString());

            return RedirectToAction("Index", "Home");
        }

        //Logout
           
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM,string?ReturnUrl)
        {
            if(!ModelState.IsValid) return View();

            AppUser userEnter =await _userManager.FindByEmailAsync(loginVM.UsernameorEmail);
            if (userEnter==null)
            {
                userEnter = await _userManager.FindByNameAsync(loginVM.UsernameorEmail);
                if(userEnter==null)
                {
                    ModelState.AddModelError("", "Username,Email or password is wrong!");
                    return View();
                }
            }
            var result =await _signInManager.PasswordSignInAsync(userEnter,loginVM.Password,loginVM.RememberMe,true);
            if (result.IsLockedOut)
            {
                    ModelState.AddModelError("", "Your account was blocked");
                    return View();
            }
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Username,Email or password is wrong!");
                return View();

            }
            await _signInManager.SignInAsync(userEnter, loginVM.RememberMe);
            if(ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            var role =await _userManager.GetRolesAsync(userEnter);
            foreach(var item in role)
            {
            if (item=="Admin")
            {
                return RedirectToAction("Index", "dashboard", new {area="AdminArea"});
            }

            }
            return RedirectToAction("Index","Home");
        }

        
    }
}