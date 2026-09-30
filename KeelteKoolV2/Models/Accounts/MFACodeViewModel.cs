using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KeelteKoolV2.Models.Accounts
{
    public class MFACodeViewModel
    {
        public string SelectedProvider { get; set; } = string.Empty;
        public ICollection<SelectListItem> Providers { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Kood")]
        public string Code { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;
        public bool RememberMe { get; set; }

        [Display(Name = "Jäta brauser meelde")]
        public bool RememberBrowser { get; set; }
    }
}
