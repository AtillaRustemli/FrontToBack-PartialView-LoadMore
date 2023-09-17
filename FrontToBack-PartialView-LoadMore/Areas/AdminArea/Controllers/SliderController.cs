using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.Extensions;
using FrontToBack_PartialView_LoadMore.ViewModels.AdminSlider;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment= webHostEnvironment;
        }

        //Index-------------------------------------------------------------------------------------------

        public IActionResult Index()
        {
            return View(_appDbContext.Slider.ToList());
        }

        //Create-------------------------------------------------------------------------------------------

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateSliderVM createSliderVM)
        {
            if(!ModelState.IsValid)
            { 
                ModelState.AddModelError("Photo", "Fayl secin!");
                return View();
            }
            if (!createSliderVM.Photo.CheckImage())
            {
                ModelState.AddModelError("Photo", "Yalniz shekil yuklemek olar!");
                return View();
            }
            if (createSliderVM.Photo.CheckSize(1024))
            {
                ModelState.AddModelError("Photo", "Sheklin Olcusu cox boyukdur!");
                return View();
            }
            
        
            Slider slider = new();
            slider.ImgUrl = createSliderVM.Photo.SaveImage("img",_webHostEnvironment);
            _appDbContext.Slider.Add(slider);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        //Delete-------------------------------------------------------------------------------------------

        public IActionResult DeleteVerification(int?id)
        {
            if (id == null) return View(); 
            var existProduct=_appDbContext.Slider.FirstOrDefault(s => s.Id == id);
            return View("_DeleteVerification", existProduct);
        }
        public IActionResult Delete(int? id) { 
         if (id == null) return NotFound();
         var existsProduct=_appDbContext.Slider.FirstOrDefault(s=>s.Id == id);
           
            if (existsProduct == null) return NotFound();
            string path=Path.Combine(_webHostEnvironment.WebRootPath,"img", existsProduct.ImgUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _appDbContext.Slider.Remove(existsProduct);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        //Detail-------------------------------------------------------------------------------------------

        public IActionResult Detail(int?id)
        {
           if(id == null) return View();
            var existSlide = _appDbContext.Slider.FirstOrDefault(s => s.Id == id);
            if(existSlide == null) return NotFound();
            return View(existSlide);
        }

        //Update-------------------------------------------------------------------------------------------

        public IActionResult Update(int? id)
        {
            if (id == null) return View();
            var existSlide= _appDbContext.Slider.FirstOrDefault(s=>s.Id==id);
            if (existSlide == null) return NotFound();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bosh qoymayin!");
                return View();
            }
            UpdateSliderVM updateSliderVM=new UpdateSliderVM
            {
                //ImgUrl=existSlide.ImgUrl,
            };
            

            return View(updateSliderVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int?id,UpdateSliderVM updateSliderVM)
        {
            
            if (id == null) return View();

            var existSlide=_appDbContext.Slider.FirstOrDefault(s=>s.Id==id);

            //updateSliderVM.ImgUrl = existSlide.ImgUrl;
            if (existSlide == null) return NotFound();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Photo", "Bosh qoymayin!!");
                return View();
            }
            if (!updateSliderVM.Photo.CheckImage())
            {
                ModelState.AddModelError("Photo", "Yalniz shekil olmalidir!!!");
                return View();
            }
            if (updateSliderVM.Photo.CheckSize(1000))
            {
                ModelState.AddModelError("Photo", "Shekilin olcusu cox boyukdur!!");
                return View();
            }
            existSlide.ImgUrl = updateSliderVM.Photo.SaveImage("img", _webHostEnvironment);
            
            
            _appDbContext.SaveChanges();


            return RedirectToAction("index");
        }

    }
}
