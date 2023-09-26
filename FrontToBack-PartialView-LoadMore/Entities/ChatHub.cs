using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class ChatHub:Hub
    {
        private readonly UserManager<AppUser> _userManager;

        public ChatHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SendMessage(string user, string message)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
