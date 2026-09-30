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
        public Task<LanguageCourse?> Create(LanguageCourseDTO dto)
        {
            return Task.FromResult<LanguageCourse?>(null);
        }

        public Task<LanguageCourse?> Update(LanguageCourseDTO dto)
        {
            return Task.FromResult<LanguageCourse?>(null);
        }

        public Task<LanguageCourse?> Details(Guid id)
        {
            return Task.FromResult<LanguageCourse?>(null);
        }

        public Task<LanguageCourse?> Delete(Guid id)
        {
            return Task.FromResult<LanguageCourse?>(null);
        }
    }
}
