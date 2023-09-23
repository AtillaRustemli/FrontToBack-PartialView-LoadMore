using FrontToBack_PartialView_LoadMore.Entities;
using Microsoft.AspNetCore.Identity;

namespace FrontToBack_PartialView_LoadMore.ViewModels.AdminRoles
{
    public class UpdateRoleVM
    {
        public List<IdentityRole> Roles { get; set; }
        public IList<string> UserRoles { get; set; }
        public AppUser User { get; set; }
    }
}
