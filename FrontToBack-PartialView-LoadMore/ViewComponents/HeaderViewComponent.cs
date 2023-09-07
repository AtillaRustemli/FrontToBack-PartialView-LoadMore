using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.ViewComponenta
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var bio = _appDbContext.Bios
                .Where(b => b.Id == id)
                .FirstOrDefault();
            return View(await Task.FromResult(bio));
        }

    }
}
