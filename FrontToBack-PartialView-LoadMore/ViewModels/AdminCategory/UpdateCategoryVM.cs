using System.ComponentModel.DataAnnotations;

namespace FrontToBack_PartialView_LoadMore.ViewModels.AdminCategory
{
    public class UpdateCategoryVM
    {
        [Required(ErrorMessage = "Bosh qoymayin")]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
