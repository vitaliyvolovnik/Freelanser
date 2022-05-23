using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
