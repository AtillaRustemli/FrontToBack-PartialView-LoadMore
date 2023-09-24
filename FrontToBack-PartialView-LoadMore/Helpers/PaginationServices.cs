namespace FrontToBack_PartialView_LoadMore.Helpers
{
    public class PaginationServices
    {
        public int GetPageCount(int count, int take)
        {
            
            return  (int)Math.Ceiling((decimal)(count) / take);
        }
    }
}
