using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatBox()
        {
            return View();
        }
    }
}
