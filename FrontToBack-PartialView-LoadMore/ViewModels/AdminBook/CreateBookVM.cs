namespace FrontToBack_PartialView_LoadMore.ViewModels.AdminBook
{
    public class CreateBookVM
    {
        public string Name{ get; set; }
        public List<int> GenreId{ get; set; }
        public List<int> AuthorId{ get; set; }
    }
}
