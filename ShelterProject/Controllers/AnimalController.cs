using Microsoft.AspNetCore.Mvc;

namespace ShelterProject.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
