using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.ViewModels.Account;
using FrontToBack_PartialView_LoadMore.ViewModels.AdminUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class UserController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }


        public IActionResult Index(string search)
        {
            var users=search==null?_userManager.Users.ToList():_userManager.Users.Where(u=>u.FullName.ToLower().Contains(search)).ToList();
            return View(users);
        }
        #region Delete
        public async Task<IActionResult> Delete(string id)
        {
            var user=await _userManager.FindByIdAsync(id);
            if (id==null)  return NotFound(); 
            await _userManager.DeleteAsync(user);
            return RedirectToAction("index");

        }
        #endregion
        #region Update
        public async Task<ActionResult> Update(string id)
        {
            var user= await _userManager.FindByIdAsync(id);
            var updateUserVM = new UpdateUserVM();
            updateUserVM.Email = user.Email;
            updateUserVM.Fullname = user.FullName;
            updateUserVM.Username = user.UserName;
            //
            return View(updateUserVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(string id,UpdateUserVM updateUserVM)
        {
            AppUser updatedUser = await _userManager.FindByIdAsync(id);
            if (!ModelState.IsValid) return View();
            updatedUser.FullName = updateUserVM.Fullname;
            updatedUser.UserName = updateUserVM.Username;
            updatedUser.Email = updateUserVM.Email;
            _appDbContext.SaveChanges();


          //var result = await _signInManager.PasswordSignInAsync(user, updateUserVM.Password, updateUserVM.RememberMe, true);
            return RedirectToAction("index");
        }
        #endregion

    }
}
