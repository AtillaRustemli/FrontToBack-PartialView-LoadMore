using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.ViewModels.AdminRoles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
   
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles=_roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(string Name)
        {
            if (string.IsNullOrEmpty(Name)) return View();
            await _roleManager.CreateAsync(new IdentityRole { Name = Name });

            return RedirectToAction("index");
        }

        //Update
        public async Task<IActionResult> Update(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if(user == null) return View();
            
            UpdateRoleVM updateRoleVM = new();
            updateRoleVM.Roles= _roleManager.Roles.ToList();
            updateRoleVM.UserRoles = await _userManager.GetRolesAsync(user);
            updateRoleVM.User = user;
            return View(updateRoleVM);
        }
    }
}
