using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;

        }
        public IActionResult Index()
        {
            HomeVM vm = new();
            vm.Slider=_appDbContext.Slider.ToList();
            vm.SliderContent=_appDbContext.SliderContent.FirstOrDefault();
            vm.Category=_appDbContext.Category.ToList();
            vm.Product=_appDbContext.Product.Include(pI=>pI.ProductImage).ToList();
            vm.About = _appDbContext.About.FirstOrDefault();
            vm.AboutList = _appDbContext.AboutList.ToList();
            
            return View(vm);
        }
    }
}
