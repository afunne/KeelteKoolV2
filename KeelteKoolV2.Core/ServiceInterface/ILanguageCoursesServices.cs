using KeelteKoolV2.Core.Domain;
using KeelteKoolV2.Core.DTO;

namespace KeelteKoolV2.Core.ServiceInterface
{
    public interface ILanguageCoursesServices
    {
        Task<LanguageCourse?> Create(LanguageCourseDTO dto);
        Task<LanguageCourse?> Update(LanguageCourseDTO dto);
        Task<LanguageCourse?> Details(Guid id);
        Task<LanguageCourse?> Delete(Guid id);
    }
}
