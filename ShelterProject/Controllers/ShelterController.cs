using Microsoft.AspNetCore.Mvc;

namespace ShelterProject.Controllers
{
    public class ShelterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
