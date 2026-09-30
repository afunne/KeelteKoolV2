using KeelteKoolV2.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace KeelteKoolV2.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Kirjuta Parool Uuesti")]
        [Compare("Password", ErrorMessage = "Paroolid ei ühti.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string PlaceHolder { get; set; } = string.Empty;

        public RegisterStatus AccountStatus { get; set; } = RegisterStatus.Pending;
    }
}
