using Microsoft.AspNetCore.Mvc;

namespace ShelterProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
