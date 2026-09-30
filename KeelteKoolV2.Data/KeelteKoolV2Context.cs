using KeelteKoolV2.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeelteKoolV2.Data
{
    public class KeelteKoolV2Context : IdentityDbContext<ApplicationUser>
    {
        public KeelteKoolV2Context(DbContextOptions<KeelteKoolV2Context> options) : base(options)
        {
        }

        //tabelid tulevad siia
        public DbSet<LanguageCourse> LanguageCourses { get; set; }
    }
}
