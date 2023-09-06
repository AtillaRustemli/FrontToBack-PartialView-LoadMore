using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.ViewComponenta
{
    public class ProductViewComponent: ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public ProductViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            var product = _appDbContext.Product
                .Include(p => p.ProductImage)
                .Include(p => p.Category)
                .Take(take)
                .ToList();
            return View(await Task.FromResult(product));
        }
    }
}
