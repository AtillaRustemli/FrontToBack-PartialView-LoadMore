namespace FrontToBack_PartialView_LoadMore.ViewModels.AdminProduct
{
    public class CreateProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public IFormFile[] Photo { get; set; }
    }
}
