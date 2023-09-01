﻿using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }
        public IActionResult Index()
        {
            var product=_appDbContext.Product
                .Include(p=>p.ProductImage)
                .Include(p=>p.Category)
                .Take(4).ToList();
            return View(product);
        }
        public IActionResult LoadMore(int skip)
        {
            var product = _appDbContext.Product
                .Include(p => p.ProductImage)
                .Include(p => p.Category)
                .Skip(skip)
                .Take(4)
                .ToList();
            return PartialView("_loadMore", product);
        }
    }
}
