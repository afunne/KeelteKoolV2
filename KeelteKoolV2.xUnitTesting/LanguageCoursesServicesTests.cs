using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using Xunit;

namespace KeelteKoolV2.xUnitTesting
{
    public class LanguageCoursesServicesTests : TestBase
    {
        [Fact] //Atribuut, mille järgi testrunner saab aru, mis meetod on test ja mis ei ole
        // Testi nimi koosneb kolmest osast:
        // 1 - kas test on tavaline (peaks tegema) või negatiivne (ei tohi teha)
        // 2 - mida parasjagu testitakse
        // 3 - mis tingimusel tulemust pärast tegevust kontrollitakse
        //                  1           2           3
        //                  \/          \/          \/
        public async Task Should_AddNewCourse_WhenResultIsReturned()
        {
            //ülesseade (Arrange)
            LanguageCourseDTO newCourseDTO = new LanguageCourseDTO();
            newCourseDTO.Nimetus = "TestKursus";
            newCourseDTO.Keel = "Eesti keel";
            newCourseDTO.Tase = "Algtase";
            newCourseDTO.Kirjeldus = "A0 tasemel eesti keele \"õpe\"";

            //tegevus (Act)
            var result = await Svc<ILanguageCoursesServices>().Create(newCourseDTO);

            //kontroll (Assert)
            Assert.NotNull(result);
            /*
             Assert on klass, mille abil saab kontrollida andmete erinevaid tingimusi, kujusid, olekuid jne.
             Praegu kontrollitakse objekti ainult ühe tingimusega - et see ei oleks tühi.
             Kui meetod pärast sisu arendamist hakkab objekti tagastama, tuleks testi täiendada
             täpsemate tingimustega, mis kontrollivad näiteks, kas andmed on samasugused,
             kindlal kujul, kindlat tüüpi jne.
             */
        }
    }
}
