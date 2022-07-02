using BLL.Services;
using Domain.Models;
using Freelanser.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserService _userService;
        private readonly CategoryService _categoryService;
        private readonly SkillService _skillService;
        public EmployeeController(UserService UserService, UserService userService, CategoryService categoryService, SkillService skillService)
        {
            this._userService = userService;
            this._categoryService = categoryService;
            this._skillService = skillService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EmployeeList(string Category)
        {
            EmployeeListModel model = new EmployeeListModel();
            
            if (Category == null)
            {
                model.Categories = (await this._categoryService.GetMainCategoriesAsync()).ToList();
                model.Employees = (await _userService.GetAllEmployeesAsync()).ToList();
            }
            else
            {
                var category = (await _categoryService.FindByNameAsync(Category)).First();
                model.Categories = (await this._categoryService.GetMainCategoriesAsync()).ToList();
                model.Employees = (await _userService.GetEmployeesBySkillCategoryesAsync(category)).ToList();
                if (category.IsMainCategory)
                {
                    model.CurrentMainCategory = category;
                }
                else
                {

                    model.CurrentCategory = category;
                    model.CurrentMainCategory = await _categoryService.FindParentCategoryAsync(Category);
                    model.CurrentMainCategory.SubCategory = model.CurrentMainCategory.SubCategory.OrderBy(x => x.Name).ToList();


                }
            }
            return View(model);
        }
        public async Task<IActionResult> EmployeeInfPage(int Id)
        {
            return View(await this._userService.GetEmployeeByIdAsync(Id));
        }
      
    }
}
