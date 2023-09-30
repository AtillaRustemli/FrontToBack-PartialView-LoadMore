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
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext appDbContext, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _roleManager = roleManager;
        }

        #region Index
        public IActionResult Index(string search)
        {
            var users=search==null?_userManager.Users.ToList():_userManager.Users.Where(u=>u.FullName.ToLower().Contains(search)).ToList();
            return View(users);
        }
        #endregion
       
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
            updatedUser.NormalizedUserName= updateUserVM.Username.ToUpper();
            updatedUser.NormalizedEmail= updateUserVM.Email.ToUpper();


            _appDbContext.SaveChanges();


            //var result = await _signInManager.PasswordSignInAsync(user, updateUserVM.Password, updateUserVM.RememberMe, true);
            return RedirectToAction("index");
        }
        #endregion
        #region Create

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateUserVM createUserVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var usersUsaerName=await _userManager.FindByNameAsync(createUserVM.Username);
            var usersEmail=await _userManager.FindByEmailAsync(createUserVM.Email);
            var usersFullName=await _userManager.FindByNameAsync(createUserVM.Username);
            var role = await _roleManager.FindByNameAsync("Member");
            if(usersFullName!=null|| usersEmail!=null|| usersUsaerName != null)
            {
                return View();
            }
            AppUser appUser = new();
            appUser.FullName = createUserVM.Fullname;
            appUser.UserName = createUserVM.Username;
            appUser.Email = createUserVM.Email;
            IdentityResult result = await _userManager.CreateAsync(appUser, createUserVM.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description.ToString());

                }
            }

            await _userManager.AddToRoleAsync(appUser, role.ToString());
            return RedirectToAction("index");
        }
        #endregion
        #region Detail
        public async Task<IActionResult> Detail(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            return View(user);
        }
        #endregion

    }
}
