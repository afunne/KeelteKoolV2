using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using KeelteKoolV2.Data;
using KeelteKoolV2.Models.LanguageCourses;
using Microsoft.AspNetCore.Mvc;

namespace KeelteKoolV2.Controllers
{
    public class LanguageCoursesController : Controller
    {
        private readonly KeelteKoolV2Context _context;
        private readonly ILanguageCoursesServices _languageCoursesServices;

        public LanguageCoursesController(KeelteKoolV2Context context, ILanguageCoursesServices languageCoursesServices)
        {
            _context = context;
            _languageCoursesServices = languageCoursesServices;
        }

        public IActionResult Index()
        {
            //kõikide kursuste kuvamine tuleb hiljem, praegu pole see testitav
            var result = _Context.LanguageCourses
                .Select(c => new LanguageCourseViewModel
                {
                    Nimetus = c.Nimetus,
                    Keel = c.Keel,
                    Tase = c.Tase,
                    Kirjeldus = c.Kirjeldus
                }).Take(20).GroupBy(c => c.Keel);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LanguageCourseViewModel vm = new();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(LanguageCourseViewModel vm)
        {
            //kontrollime, et vm ei oleks null
            if (vm == null)
            {
                return RedirectToAction("Error", "Home");
            }
            //kontrollime, et vm-i ModelState on õige
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            //teeme uue DTO-objekti ja asetame sinna vm-i andmed
            var dto = new LanguageCourseDTO()
            {
                Id = vm.Id,
                Nimetus = vm.Nimetus,
                Keel = vm.Keel,
                Tase = vm.Tase,
                Kirjeldus = vm.Kirjeldus
            };
            //teostatakse päring teenusele, teenus peab objekti tagastama
            var result = await _languageCoursesServices.Create(dto);

            //kontrollime, kas tagastatud objekt on null
            if (result == null)
            {
                //kui on, suuname vealehele
                return RedirectToAction("Error", "Home");
            }
            //kui ei, suuname tagasi indeksisse
            return RedirectToAction(nameof(Index));
        }
    }
}
