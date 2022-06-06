using BLL.Services;
using Domain.Models;
using Freelanser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Freelanser.Controllers
{
    public class WorkController : Controller
    {
        private readonly WorkService _workService;
        private readonly UserService _userService;
        private readonly CategoryService _categoryService;
        private readonly SkillService _skillService;
        public WorkController(WorkService workService, UserService userService, CategoryService categoryService, SkillService skillService)
        {
            this._workService = workService;
            this._userService = userService;
            this._categoryService = categoryService;
            this._skillService = skillService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> WorkList(string? Category)
        {
            WorkViewModel model = new WorkViewModel();
            if (Category == null)
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
                    model.CurrentMainCategory.SubCategory = model.CurrentMainCategory.SubCategory.OrderBy(x => x.Name).ToList();


                }
            }
            return View(model);
        }
        public async Task<IActionResult> WorkPage(int Id)
        {
            var work = await this._workService.GetWorkByIdAsync(Id);
            return View(work);
        }
        public async Task<IActionResult> AddWork(AddWorkModel? work)
        {
            if (work.Cateories == null)
            {
                return View(new AddWorkModel() { Cateories = (await _categoryService.GetCategoriesAsync()).ToList() });
            }
            return View(work);
        }
        [HttpPost]
        public async Task<IActionResult> PublishWork(AddWorkModel work)
        {
            var Work = new Work();
            if (string.IsNullOrWhiteSpace(work.Name)
                || string.IsNullOrWhiteSpace(work.Context)
                || work.Price < 1)
                return RedirectToAction("AddWork");


            Work.Name = work.Name;
            Work.Price = work.Price;
            Work.Validation = ValidateState.IsInQueue;
            Work.Context = work.Context;
            Work.TypeOfPayment = work.TypeOfPayment;
            Work.Finish = work.Finish;
            Work.Created = DateTime.Now;

            var skillsstr = work.SkillsStr.Split(',');
            var skills = await _skillService.GetSkillsbyNamesAsync(skillsstr.ToList());

            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var customer = (await _userService.GetUserByEmailAsync(email)).Customer;
            var category = (await _categoryService.FindByNameAsync(work.CategoryName)).First();


            Work.Customer = customer;
            Work.Category = category;
            Work.Skills = new List<Skill>();
            foreach (var item in skills)
            {
                if (category.Skill.Any(x => x.Name == item.Name))
                {
                    Work.Skills.Add(item);
                }
            }

            await this._userService.PublishWorkAsync(Work);

            return RedirectToAction("WorkList");
        }
        
        
        public async Task<IActionResult> Comment(string Text, int WorkId)
        {
            var comment = new Comment();
            comment.IsMainComment = true;
            comment.Text = Text;
            comment.CreatedTime = DateTime.Now;

            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await _userService.GetUserByEmailAsync(email);
            
            comment.User = user;

            await _workService.AddComentAsync(comment, WorkId);
            return RedirectToAction("WorkPage", new {Id= WorkId });
        }
        public async Task<IActionResult>SubComment(int CommentId, string Text, int WorkId)
        {
            var comment = new Comment();
            comment.IsMainComment = false;
            comment.Text = Text;
            comment.CreatedTime = DateTime.Now;

            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await _userService.GetUserByEmailAsync(email);

            comment.User = user;

            await _workService.AddSubCommentAsync(CommentId,comment);
            return RedirectToAction("WorkPage", new { Id = WorkId });
        }
        
    }
}
