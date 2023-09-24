namespace FrontToBack_PartialView_LoadMore.Helpers
{
    public static class PaginationServices
    {
        public static int GetPageCount(int count, int take)
        {
            return  (int)Math.Ceiling((decimal)(count) / take);
        }
    }
}
