using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index(string search)
        {
            var users=search==null?_userManager.Users.ToList():_userManager.Users.Where(u=>u.FullName.ToLower().Contains(search)).ToList();
            return View(users);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user=await _userManager.FindByIdAsync(id);
            if (id==null)  return NotFound(); 
            await _userManager.DeleteAsync(user);
            return RedirectToAction("index");

        }
    }
}
