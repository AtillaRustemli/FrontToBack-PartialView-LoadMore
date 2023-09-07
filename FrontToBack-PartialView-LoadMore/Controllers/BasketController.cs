using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetData()
        {
            HttpContext.Session.SetString("group", "P416");
            return Content("Set olundu.");
        }
         public IActionResult GetData()
        {
           var getData= HttpContext.Session.GetString("group");
            return Content("Data: "+ getData);
        }

    }
}
