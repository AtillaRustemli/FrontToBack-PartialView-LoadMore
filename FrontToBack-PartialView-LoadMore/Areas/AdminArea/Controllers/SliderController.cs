using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SliderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Slider.ToList());
        }
    }
}
