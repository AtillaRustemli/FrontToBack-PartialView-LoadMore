namespace FrontToBack_PartialView_LoadMore.Entities.DemoEntities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookGenre> BookGenre { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
        public Book()
        {
            BookAuthor = new List<BookAuthor>();
            BookGenre = new List<BookGenre>();
        }
    }
}
