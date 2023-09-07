using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.ViewComponenta
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public FooterViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            HomeVM vm = new();
             vm.Bio = _appDbContext.Bios
                .Where(b => b.Id == id)
                .Include(sm => sm.SocialMedia)
                .FirstOrDefault();
            vm.SocialMedia=_appDbContext.SocialMedia.
                ToList();
            
            return View(await Task.FromResult(vm));
        }


    }
}
