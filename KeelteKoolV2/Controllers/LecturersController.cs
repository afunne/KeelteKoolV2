using Microsoft.AspNetCore.Mvc;

namespace KeelteKoolV2.Controllers
{
    public class LecturersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
