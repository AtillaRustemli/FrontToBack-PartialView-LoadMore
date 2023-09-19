using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.Services;
using FrontToBack_PartialView_LoadMore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontToBack_PartialView_LoadMore.ViewComponenta
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //ViewBag.userFullName = null;
            //if(User.Identity.IsAuthenticated )
            //{
            //    var user=await _userManager.FindByNameAsync(User.Identity.Name);
            //    ViewBag.userFullName = user.FullName;
            //}
          

            var bio = _appDbContext.Bios
                .Where(b => b.Id == id)
                .FirstOrDefault();
            return View(await Task.FromResult(bio));
        }

    }
}
