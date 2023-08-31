using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            return View(vm);
        }
    }
}
