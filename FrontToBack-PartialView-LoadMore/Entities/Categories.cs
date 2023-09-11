namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class Categories
    {
        public int  Id { get; set; }
        public string  Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
