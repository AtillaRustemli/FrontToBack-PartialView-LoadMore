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

        //AddBasket

        public IActionResult AddBasket(int?id)
        {
            if (id == null) return NotFound();
            var existProduct=_appDbContext.Product.Include(img=>img.ProductImage).FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            
            List<BasketVM> basket= CheckBasket();
            CheckBasketCount(basket,existProduct.Id);
            
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket),new CookieOptions {MaxAge=TimeSpan.FromMinutes(20)});
            return RedirectToAction("index","home");
        }
        private void CheckBasketCount(List<BasketVM> basket, int id)
        {
            var existProductInBasket = basket.FirstOrDefault(p => p.Id == id);
            if (existProductInBasket == null)
            {
                BasketVM bm = new();
                bm.Id = id;
                bm.BasketCount = 1;
                basket.Add(bm); 
            }
            else
            {
               existProductInBasket.BasketCount++;
            }
        }

        //CheckBasket
        private List<BasketVM> CheckBasket()
        {
            List<BasketVM> basket;
            string basketCookie = Request.Cookies["basket"];
           
            if (basketCookie == null)
            {
                basket = new();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);
            }
            return basket;
        }

        //ShowBasket
         public IActionResult ShowBasket()
        {
           string basket= Request.Cookies["basket"];
            List<BasketVM> products=new();
            if(basket != null)
            {
                products=JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                products=UpdateBasket(products);
          
            }
             
            return View(products);
        }

        //UpdateBasket

        private List<BasketVM> UpdateBasket(List<BasketVM> products)
        {
            foreach (var basketProduct in products)
            {
                var existProduct = _appDbContext.Product
                    .Include(p => p.ProductImage)
                    .FirstOrDefault(p => p.Id == basketProduct.Id);
                basketProduct.Name = existProduct.Name;
                basketProduct.Id = existProduct.Id;
                basketProduct.ImgUrl = existProduct.ProductImage.FirstOrDefault(i => i.IsMain).ImgUrl;
                basketProduct.Price = existProduct.Price;
            }
            return products;
        }

        //Add

        public IActionResult Add(int?id)
        {
            var product=_appDbContext.Product.FirstOrDefault(p=>p.Id == id);
            string basket = Request.Cookies["basket"];
            var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var existPr=products.FirstOrDefault(p=>p.Id == id);
        
            existPr.BasketCount++;
            Response.Cookies.Append("basket",JsonConvert.SerializeObject( products));


            return RedirectToAction("showbasket");
        }

        //Reduce

        public IActionResult Reduce(int? id) {
            var product = _appDbContext.Product.FirstOrDefault(p => p.Id == id);
            string basket = Request.Cookies["basket"];
            var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var existPr = products.FirstOrDefault(p => p.Id == id);

            existPr.BasketCount--;
            if (existPr.BasketCount == 0)
            {
                products.Remove(existPr);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products));


            return RedirectToAction("showbasket");
        }

        //Remove

        public IActionResult Remove(int? id)
        {
            string basket = Request.Cookies["basket"];
            var product = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var existPr=product.FirstOrDefault(p=>p.Id == id);
            if (existPr != null)
            {
                product.Remove(existPr);
            }
            Response.Cookies.Append("basket",JsonConvert.SerializeObject(product),new CookieOptions {MaxAge=TimeSpan.FromMinutes(20)});
            return RedirectToAction("showbasket");
            
            
        }

        //TotalPrice

        public IActionResult TotalPrice(int? id)
        {
            var basket = Request.Cookies["basket"];
            var product=JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            double totalPrice = 0 ;
            foreach(var products in product)
            {
                totalPrice += products.Price;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket),new CookieOptions { MaxAge=TimeSpan.FromMinutes(20)});
            return RedirectToAction("showbasket");

        }


    }
}
