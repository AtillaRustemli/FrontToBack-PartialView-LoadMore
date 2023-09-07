namespace FrontToBack_PartialView_LoadMore.Entities
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int BioId { get; set; }
        public Bio Bio { get; set; }
    }
}
