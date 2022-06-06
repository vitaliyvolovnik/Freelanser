using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserService _uSerService;
        public EmployeeController(UserService UserService)
        {
            this._uSerService = UserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EmployeeList(string Category)
        {

            return View();
        }
        public async Task<IActionResult> EmployeeInfPage(int Id)
        {
           
            return View(await this._uSerService.GetEmployeeByIdAsync(Id));
        }
    }
}
