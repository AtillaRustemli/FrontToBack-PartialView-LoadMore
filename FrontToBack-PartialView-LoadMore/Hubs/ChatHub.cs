using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace FrontToBack_PartialView_LoadMore.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public ChatHub(UserManager<AppUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            var context = Context.User;
        }

        public async Task SendMessage(string user, string message)
        {
           
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                user.ConnectionId = Context.ConnectionId;
                var result = _userManager.UpdateAsync(user).Result;
                Clients.All.SendAsync("OnConnect", user.Id);
            }
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                user.ConnectionId = null;
                var result = _userManager.UpdateAsync(user).Result;
                Clients.All.SendAsync("Connect", user.Id);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
