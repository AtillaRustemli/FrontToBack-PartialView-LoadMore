using FrontToBack_PartialView_LoadMore.Entities;

namespace FrontToBack_PartialView_LoadMore.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Slider { get; set; }
        public SliderContent SliderContent { get; set; }
        public List<Product> Product { get; set; }
        public List<Categories> Category { get; set; }
        public About About { get; set; }
        public List<AboutList> AboutList { get; set; }
    }
}
