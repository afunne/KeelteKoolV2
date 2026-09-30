using Microsoft.AspNetCore.Identity;

namespace KeelteKoolV2.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Placeholder { get; set; } = string.Empty;
    }
}
