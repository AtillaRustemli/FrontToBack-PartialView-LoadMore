using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Areas.AdminArea.Controllers
{
        [Area("AdminArea")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
