namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class Bio
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Author { get; set; }
        public List<SocialMedia> SocialMedia { get; set; }
    }
}
