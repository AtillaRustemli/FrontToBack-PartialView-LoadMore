using FrontToBack_PartialView_LoadMore.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack_PartialView_LoadMore.ViewComponenta
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public FooterViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

            
    }
}
