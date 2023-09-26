using System.ComponentModel.DataAnnotations;

namespace FrontToBack_PartialView_LoadMore.ViewModels.AdminUser
{
    public class UpdateUserVM
    {
        [Required, StringLength(100)]
        public string Fullname { get; set; }
        [Required, StringLength(100)]
        public string Username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
        public bool RememberMe { get; set; }
    }
}
