namespace FrontToBack_PartialView_LoadMore.Helpers
{
    public class PaginationVM<T>
    {
        public List<T> Items { get; set; }
        public int PageCount { get; set; }
        public int InWhichPage { get; set; }
        public PaginationVM(List<T> items, int pageCount,int inWhichPage)
        {
            Items = items;
            PageCount= pageCount;
            InWhichPage = inWhichPage;
        }
   
    }
}
