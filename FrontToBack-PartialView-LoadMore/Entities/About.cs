namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainImgUrl { get; set; }
        public string MainImgIcon { get; set; }
        public List<AboutList> AboutList { get; set; }
    }
}
