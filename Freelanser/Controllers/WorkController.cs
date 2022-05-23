using BLL.Services;
using Domain.Models;
using Freelanser.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freelanser.Controllers
{
    public class WorkController : Controller
    {
        private readonly WorkService _workService;
        private readonly UserService _userService;
        private readonly CategoryService _categoryService;
        public WorkController(WorkService workService,UserService userService, CategoryService categoryService)
        {
            this._workService = workService;
            this._userService = userService;
            this._categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> WorkList(string? Category)
        {
            WorkViewModel model = new WorkViewModel();
            if(Category == null)
            {
                model.Categories = (await this._categoryService.GetMainCategoriesAsync()).ToList();
                model.Works = (await _workService.GetWorksAsync()).ToList();
            }
            else
            { 
                var category = (await _categoryService.FindByNameAsync(Category)).First();
                model.Categories = (await this._categoryService.GetMainCategoriesAsync()).ToList();
                model.Works = (await _workService.GetWorksByCategorysAsync(new Category() { Name = Category })).ToList();
                if (category.IsMainCategory)
                {
                    model.CurrentMainCategory = category;
                }
                else
                {
                    model.CurrentCategory = category;
                    model.CurrentMainCategory = await _categoryService.FindParentCategoryAsync(Category);
                }
            }
            return View(WorkViewModel);
        }
        public async Task<IActionResult> WorkPage(int Id)
        {
            var work = await this._workService.GetWorkByIdAsync(Id);
            return View(work);
        }
        public IActionResult AddWork(Work?work) => View((work==null)?new Work():work);
        [HttpPost]
        public async Task<IActionResult> PublishWork(Work work)
        {
            if(string.IsNullOrWhiteSpace(work.Name)
                || string.IsNullOrWhiteSpace(work.Context)
                || work.Price < 1)
                    return RedirectToAction("AddWork");

            await this._userService.PublishWorkAsync(work);
            return RedirectToAction("WorkList");
        }
        public async Task<IActionResult> AddFile(Work Work,IFormFile uploadFile)
        {
            
            if (uploadFile != null)
            {

                //Set Key Name
                string FileNAme = Guid.NewGuid().ToString() + Path.GetExtension(uploadFile.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", FileNAme);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    uploadFile.CopyTo(stream);
                }
                Work.Files.Add(new Domain.Models.File() { Name = uploadFile.FileName, Path = SavePath });
            }
            
            return RedirectToAction("AddFile", new { Work = Work });

        }
        public async Task<IActionResult> Comment(Comment comment, int WorkId)
        {
            return RedirectToAction("WorkPage");
        }
    }
}
