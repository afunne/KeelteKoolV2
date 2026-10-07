using KeelteKoolV2.Core.Domain;
using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using KeelteKoolV2.Data;

namespace KeelteKoolV2.ApplicationServices.Services
{
    public class LanguageCoursesServices : ILanguageCoursesServices
    {
        private readonly KeelteKoolV2Context _context;

        public LanguageCoursesServices(KeelteKoolV2Context context)
        {
            _context = context;
        }

        //TDD: meetodid on esialgu tühjad, et saaks enne sisu arendamist testid kirjutada.
        //Testid peavad praegu ebaõnnestuma (punane), pärast sisu kirjutamist õnnestuma (roheline).
        public async Task<LanguageCourse?> Create(LanguageCourseDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            var domain = new LanguageCourse
            {
                Id = Guid.NewGuid(),
                Nimetus = dto.Nimetus,
                Keel = dto.Keel,
                Tase = dto.Tase ?? string.Empty,
                Kirjeldus = dto.Kirjeldus ?? string.Empty,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = dto.ModifiedBy
            };

            await _context.LanguageCourses.AddAsync(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<LanguageCourse?> Update(LanguageCourseDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            var domain = await _context.LanguageCourses.FindAsync(dto.Id);
            if (domain == null)
            {
                return null;
            }

            domain.Nimetus = dto.Nimetus;
            domain.Keel = dto.Keel;
            domain.Tase = dto.Tase ?? string.Empty;
            domain.Kirjeldus = dto.Kirjeldus ?? string.Empty;
            domain.ModifiedAt = DateTime.UtcNow;
            domain.ModifiedBy = dto.ModifiedBy;
            await _context.SaveChangesAsync();
            return domain;
        }

        public Task<LanguageCourse?> Details(Guid id)
        {
            return Task.FromResult<LanguageCourse?>(null);
        }

        public async Task<LanguageCourse?> Delete(Guid id)
        {
            var domain = await _context.LanguageCourses.FindAsync(id);
            if (domain == null)
            {
                return null;
            }

            _context.LanguageCourses.Remove(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
    }
}
