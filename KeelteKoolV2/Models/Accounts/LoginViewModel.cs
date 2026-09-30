using System.ComponentModel.DataAnnotations;

namespace KeelteKoolV2.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Emailiaadress")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parool")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Mäleta sisselogitust")]
        public bool RememberMe { get; set; }
    }
}
