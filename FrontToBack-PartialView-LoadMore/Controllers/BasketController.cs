using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BasketController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBasket(int?id)
        {
            if (id == null) return NotFound();
            var existProduct=_appDbContext.Product.Include(img=>img.ProductImage).FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            List<BasketVM> basket;
            string basketCookie = Request.Cookies["basket"];
            if (basketCookie == null)
            {
                basket = new();
            }
            else { 
                 basket=  JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);
            }
            var existProductInBasket = basket.FirstOrDefault(p => p.Id == id);
           
            if (existProductInBasket == null)
            {
                BasketVM bm = new();
                bm.Id = existProduct.Id;
                bm.Name = existProduct.Name;
                bm.Price = existProduct.Price;
                bm.ImgUrl = existProduct.ProductImage.FirstOrDefault(p=>p.IsMain).ImgUrl;
                bm.BasketCount = 1;
                basket.Add(bm); 
            }
            else
            {
               existProductInBasket.BasketCount++;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket),new CookieOptions {MaxAge=TimeSpan.FromMinutes(20)});
            return RedirectToAction("index","home");
        }
         public IActionResult ShowBasket()
        {
           string basket= Request.Cookies["basket"];
            List<BasketVM> products=new();
            if(basket != null)
            {
                products=JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            foreach (var basketProduct in products)
            {
                    var existProduct=_appDbContext.Product
                        .Include(p=>p.ProductImage)
                        .FirstOrDefault(p=> p.Id == basketProduct.Id);
                    basketProduct.Name= existProduct.Name;
                    basketProduct.Id= existProduct.Id;
                    basketProduct.ImgUrl= existProduct.ProductImage.FirstOrDefault(i=>i.IsMain).ImgUrl;
                    basketProduct.Price= existProduct.Price;
            }
            }
             
            return View(products);
        }
        public IActionResult Add(int?id)
        {
            BasketVM basketVM = new();
            basketVM.BasketCount++;
            return RedirectToAction("showbasket");
        }

    }
}
