using Microsoft.AspNetCore.Identity;

namespace KeelteKoolV2.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Placeholder { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public RegisterStatus AccountStatus { get; set; }
    }
}
