namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Categories Category { get; set; }
        public List<ProductImage> ProductImage { get; set; }
    }
}
