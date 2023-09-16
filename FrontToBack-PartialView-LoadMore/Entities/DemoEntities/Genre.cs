namespace FrontToBack_PartialView_LoadMore.Entities.DemoEntities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookGenre> BookGenre { get; set; }
    }
}
