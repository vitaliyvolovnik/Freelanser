using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
