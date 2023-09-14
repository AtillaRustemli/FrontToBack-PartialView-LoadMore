using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
    private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Index
        public IActionResult Index()
        {   
            var product=_appDbContext.Product
                .Include(p=>p.Category)
                .Include(p=>p.ProductImage)
                .ToList();
            return View(product);
        }

        //Create
        public IActionResult Create()
        {
            ViewBag.Categories=new SelectList(_appDbContext.Category,"Id","Name");

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_appDbContext.Category, "Id", "Name");

            return View();
        }
    }
}
