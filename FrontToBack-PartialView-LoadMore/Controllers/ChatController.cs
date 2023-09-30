using FrontToBack_PartialView_LoadMore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FrontToBack_PartialView_LoadMore.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<ChatHub> _hub;

        public ChatController(UserManager<AppUser> userManager, IHubContext<ChatHub> hub)
        {
            _userManager = userManager;
            _hub = hub;
        }

        public IActionResult ChatBox()
        {
            ViewBag.Users =_userManager.Users.ToList();
            return View();
        }
        public async Task<IActionResult> SendToClient(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            await _hub.Clients.Client(user.ConnectionId).SendAsync("RecieveFromUser",userId);
            if (_hub.Clients.Client(user.ConnectionId) == null) return NotFound();
            return Content("Mesaj Gonderildi...");
        }
    }
}
