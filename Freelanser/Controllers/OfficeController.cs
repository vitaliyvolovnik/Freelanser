using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
