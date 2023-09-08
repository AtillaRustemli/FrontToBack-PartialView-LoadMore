using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            ViewBag.Count = 0;
            string basket = Request.Cookies["basket"];
            if(basket!= null) { 
            var product=JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                ViewBag.Count = product.Count;
            }

            var bio = _appDbContext.Bios
                .Where(b => b.Id == id)
                .FirstOrDefault();
            return View(await Task.FromResult(bio));
        }

    }
}
