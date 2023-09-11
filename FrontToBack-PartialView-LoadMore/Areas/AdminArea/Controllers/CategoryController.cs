using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{  
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Category.ToList());
        }
        public IActionResult Detail(int?id)
        {
            if(id==null) return NotFound();
            var existCategory = _appDbContext.Category.FirstOrDefault(c => c.Id == id);
            if(existCategory==null) return NotFound();
            return View(existCategory);
        }
    }
}
