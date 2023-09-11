using FrontToBack_PartialView_LoadMore.ViewModels;
using Newtonsoft.Json;

namespace FrontToBack_PartialView_LoadMore.Services
{
    public class BasketService : IBasket
    {
        private IHttpContextAccessor _contextAccessor;

        public BasketService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetBasketCount()
        {
            string basket = _contextAccessor.HttpContext.Request.Cookies["basket"];
            if (basket != null)
            {
                var product = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                return product.Count;
            }
            return 0;
        }
    }
}
