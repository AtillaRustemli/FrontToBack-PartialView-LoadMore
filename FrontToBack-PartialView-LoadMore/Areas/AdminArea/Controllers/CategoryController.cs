using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.ViewModels.AdminCategory;
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

        //Index

        public IActionResult Index()
        {
            return View(_appDbContext.Category.ToList());
        }

        //Detail
        public IActionResult Detail(int?id)
        {
            if(id==null) return NotFound();
            var existCategory = _appDbContext.Category.FirstOrDefault(c => c.Id == id);
            if(existCategory==null) return NotFound();
            return View(existCategory);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCategoryVM createCategoryVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if(_appDbContext.Category.Any(c=>c.Name.ToLower()== createCategoryVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", ("Eyni adli kateqoriya yaratmaq olmaz!"));
                return View();
            }
            Categories categories = new();
            categories.Name = createCategoryVM.Name;
            categories.Desc=createCategoryVM.Desc;
            _appDbContext.Category.Add(categories);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        //Update
       
        public IActionResult Update(int?id)
        {
            if(id==null) return NotFound();
            var existCategory= _appDbContext.Category.FirstOrDefault(c=>c.Id==id);
            if(existCategory==null) return NotFound();
            var updateCategoryVM=new UpdateCategoryVM { Name= existCategory.Name ,Desc= existCategory.Desc};
            return View(updateCategoryVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int?id,UpdateCategoryVM updateCategoryVM)
        {
            if (!ModelState.IsValid) { return View(); }
            if(id==null) return NotFound();
            var existCategory = _appDbContext.Category.FirstOrDefault(c=>c.Id==id);
            if (_appDbContext.Category.Any(c => c.Name == updateCategoryVM.Name && c.Id != id)) {
                ModelState.AddModelError("Name", "Bu adda kateqoriya artiq movcuddur!");
                return View();
            }
            existCategory.Desc= updateCategoryVM.Desc;
            existCategory.Name= updateCategoryVM.Name;
            _appDbContext.SaveChanges();

            return View();
        }

        //Delete

        public IActionResult DeleteMinitab(int?id)
        {
            if(id==null) return NotFound();
            var existCategory = _appDbContext.Category.FirstOrDefault(c => c.Id == id);
            return View("_DeleteMiniTab", existCategory);
        }
        public IActionResult Delete(int?id)
        {
            if(id==null) return NotFound();
            var existCategory= _appDbContext.Category.FirstOrDefault(c=>c.Id==id);
            if(existCategory==null) return NotFound();
            _appDbContext.Category.Remove(existCategory);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
