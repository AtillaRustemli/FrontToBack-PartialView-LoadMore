namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class AboutList
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Content { get; set; }
        public About About { get; set; }
        public int AboutId { get; set; }
    }
}
