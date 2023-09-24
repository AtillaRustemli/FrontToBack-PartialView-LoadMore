using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.Extensions;
using FrontToBack_PartialView_LoadMore.Helpers;
using FrontToBack_PartialView_LoadMore.ViewModels.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        //Index
        public IActionResult Index(int PrevNext=0,int page=1,int take=4)
        {
            var query=_appDbContext.Product.AsQueryable();
            var product =query
                .Include(p => p.Category)
                .Include(p => p.ProductImage)
                .AsNoTracking()
                .Skip((page-1)*take)
                .Take(take)
                .ToList();
            

            var pagination = new PaginationVM<Product>(product,GetPageCount(query.Count(),take) , page);
            return View(pagination);
        }
        public int GetPageCount(int count, int take)
        {
            var pageCount = (int)Math.Ceiling((decimal)(count) / take);
            return pageCount;
        }
        //Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_appDbContext.Category, "Id", "Name");

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateProductVM createProductVM)
        {
            ViewBag.Categories = new SelectList(_appDbContext.Category, "Id", "Name");
            if (!ModelState.IsValid) return View();
            Product newProduct = new();
            newProduct.Name = createProductVM.Name;
            newProduct.Price = createProductVM.Price;
            newProduct.CategoryId = createProductVM.CategoryId;
            newProduct.ProductImage = new();
            foreach (var photo in createProductVM.Photo)
            {
                if (!photo.CheckImage())
                {
                    ModelState.AddModelError("Photo", "Yalnis shekil gondere bilersiniz!!!");
                    return View();
                }
                if (photo.CheckSize(1000))
                {
                    ModelState.AddModelError("Photo", "Sheklin Olcusu cox boyukdur!!!");
                    return View();
                }
                ProductImage productImage = new();

                if (photo == createProductVM.Photo[0])
                {
                    productImage.IsMain = true;
                }
                productImage.ImgUrl = photo.SaveImage("img", _webHostEnvironment);
                newProduct.ProductImage.Add(productImage);
            }
            _appDbContext.Product.Add(newProduct);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
