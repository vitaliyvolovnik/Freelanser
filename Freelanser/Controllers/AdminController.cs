using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
