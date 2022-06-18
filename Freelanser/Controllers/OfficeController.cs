using BLL.Services;
using Freelanser.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace Freelanser.Controllers
{
    [Authorize]
    public class OfficeController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public readonly UserService _userService;
        public readonly CategoryService _categoryService;
        public readonly SkillService _skillService;
        public OfficeController(UserService service, IHostingEnvironment environment, CategoryService categoryService, SkillService skillService)
        {
            this._userService = service;
            _environment = environment;
            this._categoryService = categoryService;
            this._skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {
            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await this._userService.GetUserByEmailAsync(email);
            if (user == null)
                return RedirectToAction("index", new { @Controller = "Home" });
            else if (user.IsWorker)
                return RedirectToAction("EmployeeAccount", new { id = user.Employee.Id });
            else
                return RedirectToAction("CustomerAccount", new { id = user.Customer.Id });
        }

        public async Task<IActionResult> CustomerAccount()
        {
            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await this._userService.GetUserByEmailAsync(email);
            if (user == null)
                return RedirectToAction("index", new { @Controller = "Home" });
            else if (!user.IsWorker)
                return View(await this._userService.GetCstomerByIdAsync(user.Customer.Id));
            else
                return RedirectToAction("EmployeeAccount");

        }

        public async Task<IActionResult> EmployeeAccount()
        {
            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await this._userService.GetUserByEmailAsync(email);
            if (user == null)
                return RedirectToAction("index", new { @Controller = "Home" });
            else if (user.IsWorker)
                return View(await this._userService.GetEmployeeByIdAsync(user.Employee.Id));
            else
                return RedirectToAction("CustomerAccount");
        }
        public async Task<IActionResult> ChangePhoto(int UserInfId)
        {

            var rootPath = _environment.WebRootPath;
            rootPath = Path.Combine(rootPath, "Images");
            var savepath = Path.Combine(rootPath, Request.Form.Files[0].FileName);
            using (var stream = System.IO.File.Create(savepath))
            {
                Request.Form.Files[0].CopyTo(stream);
            }


            var path = Path.Combine("~/Images/", Request.Form.Files[0].FileName);
            await _userService.ChangePhotoAsync(UserInfId, path);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditInfo()
        {
            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await this._userService.GetUserByEmailAsync(email);

            var model = new EditViewModel();
            if (user == null)
                return RedirectToAction("index", new { @Controller = "Home" });
            model.Information = user.UserInfo.Information;
            model.Name = user.UserInfo.Name;
            model.Surname = user.UserInfo.Surname;
            model.Phone = user.UserInfo.Phone;
            model.UserInfoId = user.UserInfo.Id;
            

            if (user.IsWorker)
            {
                foreach (var skill in user.Employee.Skills)
                    model.SkillsStr += skill.Name + ",";
                if (user.Employee.Skills.Count > 0)
                    model.SkillsStr = model.SkillsStr.Remove(model.SkillsStr.Length - 1);
                model.Categories = await _categoryService.GetCategoriesAsync();
                return View(model);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditInfo(EditViewModel model)
        {
            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await this._userService.GetUserByEmailAsync(email);
            if (user == null)
                return RedirectToAction("index", new { @Controller = "Home" });
            user.UserInfo.Name = model.Name;
            user.UserInfo.Surname = model.Surname;
            user.UserInfo.Phone = model.Phone;
            user.UserInfo.Information = model.Information;
            if (user.IsWorker)
            {
                var skillsstr = model.SkillsStr.Split(',');
                var skills = await _skillService.GetSkillsbyNamesAsync(skillsstr.ToList());
                user.Employee.Skills = skills.ToList();
            }
            await _userService.EditInfoAsync(user);
            return RedirectToAction("index");
        }
        public async Task<ActionResult> Works(bool isFinished)
        {
            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = await this._userService.GetUserByEmailWithWorksAsync(email);
            if (user == null)
                return RedirectToAction("index", new { @Controller = "Home" });
            else if (user.IsWorker)
            {
                user.Employee.ExecutedWorks = user.Employee.ExecutedWorks.Where(x => x.IsFinished == isFinished).ToList();
                return View(user);
            }
            else
            {
                user.Customer.Work = user.Customer.Work.Where(x => x.IsFinished == isFinished).ToList();
                return View(user);
            }
        }
    }
}
