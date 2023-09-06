using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.ViewComponenta
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
    }
}
