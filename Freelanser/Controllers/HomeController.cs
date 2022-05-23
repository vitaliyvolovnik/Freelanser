using BLL.Services;
using Freelanser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domain.Models;

namespace Freelanser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryService _categoryService; 

        public HomeController(ILogger<HomeController> logger, CategoryService categoryService)
        {
            _logger = logger; 
            this._categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            //await SetDefaultCategory();
            return View(await _categoryService.GetMainCategoriesAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task SetDefaultCategory()
        {
            var List=new List<Category>();
            //List.Add(new Category()
            //    {
            //        Name = "Programming & Development",
            //        IsMainCategory = true,
            //    });
            //List.Add(new Category()
            //{
            //    Name = "Design & Art",
            //    IsMainCategory = true,
            //});
            //List.Add(new Category()
            //{
            //    Name = "Writing & Translation",
            //    IsMainCategory = true,
            //});
            //List.Add(new Category()
            //{
            //    Name = "Administrative & Secretarial",
            //    IsMainCategory = true,
            //});
            //List.Add(new Category()
            //{
            //    Name = "Sales & Marketing",
            //    IsMainCategory = true,
            //});
            //List.Add(new Category()
            //{
            //    Name = "Engineering & Architecture",
            //    IsMainCategory = true,
            //});
            List.Add(new Category()
            {
                Name = "Education & Training",
                IsMainCategory = true,
            });
            List.Add(new Category()
            {
                Name = "Business & Finance",
                IsMainCategory = true,
            });
            foreach (var item in List)
            {
                await _categoryService.AddCategoryAsync(item);
            }
           
        }
    }
}