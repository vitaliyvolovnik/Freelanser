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
            var List = new List<Category>();
            List.Add(new Category()
            {
                Name = "Programming & Development",
                IsMainCategory = true,
            });
            List.Add(new Category()
            {
                Name = "Design & Art",
                IsMainCategory = true,
            });
            List.Add(new Category()
            {
                Name = "Writing & Translation",
                IsMainCategory = true,
            });
            List.Add(new Category()
            {
                Name = "Administrative & Secretarial",
                IsMainCategory = true,
            });
            List.Add(new Category()
            {
                Name = "Sales & Marketing",
                IsMainCategory = true,
            });
            List.Add(new Category()
            {
                Name = "Engineering & Architecture",
                IsMainCategory = true,
            });
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
            var cat1 = new Category()
            {
                Name = "Web Development & Design",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Web Development" },
                    new Skill()  { Name="Front End Development" },
                    new Skill()  { Name="Back End Development" },
                    new Skill()  { Name="PHP" },
                    new Skill()  { Name="Content Management System" },
                    new Skill()  { Name="User Experience Design" },
                    new Skill()  { Name="WordPress" },
                    new Skill()  { Name="E Commerce" },
                    new Skill()  { Name="Web Servers" },
                    new Skill()  { Name="Communications Technology" },
                    new Skill()  { Name="Web Hosting" },
                    new Skill()  { Name="Mockups" },
                    new Skill()  { Name="Web Graphics" },
                }

            };
            var cat2 = new Category()
            {
                Name = "Programming & Software",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Programming" },
                    new Skill()  { Name="JavaScript" },
                    new Skill()  { Name="Microsoft" },
                    new Skill()  { Name="Java" },
                    new Skill()  { Name="SQL" },
                    new Skill()  { Name="API" },
                    new Skill()  { Name="C#" },
                    new Skill()  { Name="Apple Development" },
                    new Skill()  { Name="XML" },
                    new Skill()  { Name="Python" },
                    new Skill()  { Name="C++" },
                    new Skill()  { Name="Financial Services" },
                    new Skill()  { Name="Linux" },
                    new Skill()  { Name="JSON" },
                    new Skill()  { Name="Perl" },
                    new Skill()  { Name="Open Source" },
                    new Skill()  { Name="Objective-C" },
                    new Skill()  { Name="Artificial Intelligence" },
                    new Skill()  { Name="Data Extraction" },
                    new Skill()  { Name="Embedded Development" },
                }
            };

            var SubCategories = new List<Category>();
            SubCategories.Add(cat1);
            SubCategories.Add(cat2);
            await _categoryService.AddSubCategory(1, SubCategories);

            
        }
    }
}