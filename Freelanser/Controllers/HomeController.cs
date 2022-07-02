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

        public HomeController(ILogger<HomeController> logger,  CategoryService categoryService)
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
            //var List = new List<Category>();
            //List.Add(new Category()
            //{
            //    Name = "Programming & Development",
            //    IsMainCategory = true,
            //});
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
            //List.Add(new Category()
            //{
            //    Name = "Education & Training",
            //    IsMainCategory = true,
            //});
            //List.Add(new Category()
            //{
            //    Name = "Business & Finance",
            //    IsMainCategory = true,
            //});
            //foreach (var item in List)
            //{
            //    await _categoryService.AddCategoryAsync(item);
            //}
            //var cat1 = new Category()
            //{
            //    Name = "Web Development & Design",
            //    IsMainCategory = false,
            //    Skill = new List<Skill>()
            //    {
            //        new Skill()  { Name="Web Development" },
            //        new Skill()  { Name="Front End Development" },
            //        new Skill()  { Name="Back End Development" },
            //        new Skill()  { Name="PHP" },
            //        new Skill()  { Name="Content Management System" },
            //        new Skill()  { Name="User Experience Design" },
            //        new Skill()  { Name="WordPress" },
            //        new Skill()  { Name="E Commerce" },
            //        new Skill()  { Name="Web Servers" },
            //        new Skill()  { Name="Communications Technology" },
            //        new Skill()  { Name="Web Hosting" },
            //        new Skill()  { Name="Mockups" },
            //        new Skill()  { Name="Web Graphics" },
            //    }

            //};
            //var cat2 = new Category()
            //{
            //    Name = "Programming & Software",
            //    IsMainCategory = false,
            //    Skill = new List<Skill>()
            //    {
            //        new Skill()  { Name="Programming" },
            //        new Skill()  { Name="JavaScript" },
            //        new Skill()  { Name="Microsoft" },
            //        new Skill()  { Name="Java" },
            //        new Skill()  { Name="SQL" },
            //        new Skill()  { Name="API" },
            //        new Skill()  { Name="C#" },
            //        new Skill()  { Name="Apple Development" },
            //        new Skill()  { Name="XML" },
            //        new Skill()  { Name="Python" },
            //        new Skill()  { Name="C++" },
            //        new Skill()  { Name="Financial Services" },
            //        new Skill()  { Name="Linux" },
            //        new Skill()  { Name="JSON" },
            //        new Skill()  { Name="Perl" },
            //        new Skill()  { Name="Open Source" },
            //        new Skill()  { Name="Objective-C" },
            //        new Skill()  { Name="Artificial Intelligence" },
            //        new Skill()  { Name="Data Extraction" },
            //        new Skill()  { Name="Embedded Development" },
            //    }
            //};
            //var cat3 = new Category()
            //{
            //    Name = "Apps & Mobile",
            //    IsMainCategory = false,
            //    Skill = new List<Skill>()
            //    {
            //        new Skill()  { Name="App & Mobile Programming" },
            //        new Skill()  { Name="Responsive Web Design" },
            //        new Skill()  { Name="Game Development" },
            //        new Skill()  { Name="Mobile App Marketing" },
            //    }
            //};
            //var cat4 = new Category()
            //{
            //    Name = "Apps & Mobile",
            //    IsMainCategory = false,
            //    Skill = new List<Skill>()
            //    {
            //        new Skill()  { Name="MySQL" },
            //        new Skill()  { Name="SQL" },
            //        new Skill()  { Name="Microsoft SQL Server" },
            //        new Skill()  { Name="Oracle" },
            //        new Skill()  { Name="Database Development" },
            //        new Skill()  { Name="MongoDB" },
            //        new Skill()  { Name="SQLite" },
            //        new Skill()  { Name="FoxPro" },
            //        new Skill()  { Name="Transact SQL" },
            //        new Skill()  { Name="Graph Database" },
            //    }
            //};
            /*var cat5 = new Category()
            {
                Name = "Graphic & Layout Design",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Adobe Software" },
                    new Skill()  { Name="Graphic Design" },
                    new Skill()  { Name="Logo Design" },
                    new Skill()  { Name="Ad Design" },
                    new Skill()  { Name="T Shirt Design" },
                    new Skill()  { Name="Digital Media" },
                    new Skill()  { Name="Layout Design" },
                    new Skill()  { Name="Brand Identity" },
                    new Skill()  { Name="Color Design" },
                    new Skill()  { Name="Technical Drawing" },
                    new Skill()  { Name="Industrial Design" },
                    new Skill()  { Name="Greeting Card Design" },
                    new Skill()  { Name="Display Advertising" },
                    new Skill()  { Name="Graphs" },
                    new Skill()  { Name="Augmented Reality (AR)" },
                    new Skill()  { Name="3D Modeling" },
                    new Skill()  { Name="Typography" },
                }
            };
            var cat6 = new Category()
            {
                Name = "General / Other Art",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Artist" },
                    new Skill()  { Name="Creative Design" },
                    new Skill()  { Name="Logo Design" },
                    new Skill()  { Name="Portraits" },
                    new Skill()  { Name="Fine Art" },
                    new Skill()  { Name="Minimalist Design" },
                    new Skill()  { Name="Design Education" },
                    new Skill()  { Name="NFT" },
                    new Skill()  { Name="Traditional Media" },
                    new Skill()  { Name="Pop Culture" },
                    new Skill()  { Name="Art History" },
                }
            };
            var cat7 = new Category()
            {
                Name = "Concepts & Direction",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Director" },
                    new Skill()  { Name="Concept Development" },
                    new Skill()  { Name="Concept Art" },
                    new Skill()  { Name="Ideation" },
                    new Skill()  { Name="Creative Direction" },
                    new Skill()  { Name="Art Director" },
                    new Skill()  { Name="Content Curation" },
                    new Skill()  { Name="Production Artist" },
                    new Skill()  { Name="Editorial Consulting" },
                }
            };
            var cat8 = new Category()
            {
                Name = "Animation (2D / 3D / Traditional / Motion)",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Animation" },
                    new Skill()  { Name="Adobe After Effects" },
                    new Skill()  { Name="3D Animation" },
                    new Skill()  { Name="2D Animation" },
                    new Skill()  { Name="Logo Animation" },
                    new Skill()  { Name="Storyboarding" },
                    new Skill()  { Name="Animated Video" },
                    new Skill()  { Name="Motion Animation" },
                    new Skill()  { Name="Character Animation" },
                }
            };
            */
            /* var cat9 = new Category()
             {
                 Name = "General / Other Writing",
                 IsMainCategory = false,
                 Skill = new List<Skill>()
                 {
                     new Skill()  { Name="Creative Writing" },
                     new Skill()  { Name="Descriptive Writing" },
                     new Skill()  { Name="Letter Writing" },
                     new Skill()  { Name="Document Conversion" },
                     new Skill()  { Name="Formal Writing" },
                     new Skill()  { Name="Summary Writing" },
                     new Skill()  { Name="Manuscript" },
                     new Skill()  { Name="Concept Writing" },
                     new Skill()  { Name="Persuasive Writing" },
                     new Skill()  { Name="Redacción" },
                     new Skill()  { Name="Analytical Writing" },
                     new Skill()  { Name="Prose" },
                 }
             };
             var cat10 = new Category()
             {
                 Name = "Articles & News",
                 IsMainCategory = false,
                 Skill = new List<Skill>()
                 {
                     new Skill()  { Name="Article Writing" },
                     new Skill()  { Name="Blog Writing" },
                     new Skill()  { Name="Article Editing" },
                     new Skill()  { Name="Newsletters" },
                     new Skill()  { Name="Journalism" },
                     new Skill()  { Name="News Writing" },
                     new Skill()  { Name="Magazine Articles" },
                     new Skill()  { Name="Newspaper" },
                     new Skill()  { Name="Lifestyle Writing" },
                     new Skill()  { Name="Journalistic Writing" },
                     new Skill()  { Name="Content Curation" },
                     new Skill()  { Name="Investigative Reporting" },
                 }
             };
             var cat11 = new Category()
             {
                 Name = "Industry Specific Expertise",
                 IsMainCategory = false,
                 Skill = new List<Skill>()
                 {
                     new Skill()  { Name="Educational Consulting" },
                     new Skill()  { Name="Marketing Materials" },
                     new Skill()  { Name="Business Writing" },
                     new Skill()  { Name="Medical Writing" },
                     new Skill()  { Name="Travel Writing" },
                     new Skill()  { Name="Science Writing" },
                     new Skill()  { Name="Food Writing" },
                     new Skill()  { Name="Psychology Writing" },
                     new Skill()  { Name="Romance Writing" },
                     new Skill()  { Name="Fantasy Writing" },
                     new Skill()  { Name="Instructional Design" },
                     new Skill()  { Name="Fitness Writing" },
                 }
             };
             var cat12 = new Category()
             {
                 Name = "Web Content",
                 IsMainCategory = false,
                 Skill = new List<Skill>()
                 {
                     new Skill()  { Name="Content Writing" },
                     new Skill()  { Name="Blog Writing" },
                     new Skill()  { Name="Web Content Writing" },
                     new Skill()  { Name="Keyword Research" },
                     new Skill()  { Name="Content Editing" },
                     new Skill()  { Name="Content Marketing" },
                     new Skill()  { Name="Content Management" },
                     new Skill()  { Name="LinkedIn Profile" },
                     new Skill()  { Name="On-Page SEO" },
                     new Skill()  { Name="Blog Management" },
                     new Skill()  { Name="Forum Posting" },
                     new Skill()  { Name="Web Authoring" },
                 }
             };*/
            var cat13 = new Category()
            {
                Name = "Data Entry (Keying / Cleaning)",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Data Entry" },
                    new Skill()  { Name="Data Analysis" },
                    new Skill()  { Name="Copy and Paste" },
                    new Skill()  { Name="Data Mining" },
                    new Skill()  { Name="Data Collection" },
                    new Skill()  { Name="Data Processing" },
                    new Skill()  { Name="Form Filling" },
                    new Skill()  { Name="Document Conversion" },
                    new Skill()  { Name="Order Processing" },
                    new Skill()  { Name="File Management" },
                    new Skill()  { Name="Keyboarding" },
                    new Skill()  { Name="Data Audit" },
                    new Skill()  { Name="Data Cleaning" },
                    
                    
                    
                }
            };
            var cat14= new Category()
            {
                Name = "Health & Medical",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Medical Transcription" },
                    new Skill()  { Name="Nursing" },
                    new Skill()  { Name="Health Insurance" },
                    new Skill()  { Name="Health Information Management" },
                    new Skill()  { Name="Medical Billing and Coding" },
                    new Skill()  { Name="Medisoft" },
                    new Skill()  { Name="Patient Education" },
                }
            };
            var cat15 = new Category()
            {
                Name = "Planning & Scheduling",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Event Planning" },
                    new Skill()  { Name="Calendar Management" },
                    new Skill()  { Name="Scheduling" },
                    new Skill()  { Name="Appointment Setting" },
                    new Skill()  { Name="Travel Planning" },
                    new Skill()  { Name="Hotel Booking" },
                    new Skill()  { Name="Wedding Planning" },
                    new Skill()  { Name="Airline Reservations" },
                    
                }
            };
            var cat16 = new Category()
            {
                Name = "Presentations",
                IsMainCategory = false,
                Skill = new List<Skill>()
                {
                    new Skill()  { Name="Microsoft PowerPoint" },
                    new Skill()  { Name="Slideshow Design" },
                    new Skill()  { Name="Data Presentation" },
                    new Skill()  { Name="Google Slides" },
                    new Skill()  { Name="Sales Presentations" },
                    new Skill()  { Name="Client Presentation" },
                    new Skill()  { Name="Web Presentations" },
                    new Skill()  { Name="Harvard Graphics" },
                    

                }
            };
            var SubCategories = new List<Category>();
            SubCategories.Add(cat13);
            SubCategories.Add(cat14);
            SubCategories.Add(cat15);
            SubCategories.Add(cat16);
            await _categoryService.AddSubCategory(4, SubCategories);

            
        }
    }
}