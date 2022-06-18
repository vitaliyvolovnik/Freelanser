using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class AdminController : Controller
    {

        private readonly CategoryService _categoryService;
        private readonly SkillService _skillService;
        private readonly UserService _userService;
        private readonly WorkService _workService;
        public AdminController(CategoryService CategoryService, SkillService SkillService, UserService UserService, WorkService WorkService)
        {
            this._categoryService = CategoryService;
            this._skillService = SkillService;
            this._userService = UserService;
            this._workService = WorkService;
        }


        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> ViewAllEmployee()
        {
            return View(await this._userService.GetAllEmployeesAsync());
        }
        public IActionResult AddCategory() => View();
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
                return RedirectToAction("AddSkill");
            await this._categoryService?.AddCategoryAsync(category);
            return RedirectToAction("index");
        }

        public IActionResult AddSkill() => View();
        [HttpPost]
        public async Task<IActionResult> AddSkillAsync(Skill skill)
        {
            if (string.IsNullOrEmpty(skill.Name))
                return RedirectToAction("AddSkill");
            if (await this._skillService?.AddSkillAsync(skill))
                return RedirectToAction("AddSkill");
            return RedirectToAction("index");
        }
        /* public IActionResult BlockEmployee(int id)
        {
            return View();
        }*/
        public async Task<IActionResult> ValidateList()
        { 
            return View(await this._workService.GetWorksByValidStateAsync(ValidateState.IsInQueue));
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmWork(int WorkId)
        {
            await this._workService.ChangeValidStateAsync(WorkId, ValidateState.IsValid);
            return View();
        }

        public async Task<IActionResult> RejectWork(int WorkId)
        {
            await this._workService.ChangeValidStateAsync(WorkId, ValidateState.IsCanseled);
            return RedirectToAction();
        }


    }
}
