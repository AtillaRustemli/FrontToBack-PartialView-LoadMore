using Microsoft.AspNetCore.Identity;

namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
