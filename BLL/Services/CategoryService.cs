using BLL.Services.Interfaces;
using DLL;
using DLL.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryService(CategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<OperationDetail> AddCategoryAsync(Category category)
        => await _categoryRepository.CreateAsync(category);
        public Task<IReadOnlyCollection<Category>> FindByConditionAsync(Expression<Func<Category, bool>> prediacte)
        => _categoryRepository.FindByConditioAsync(prediacte);
        public async Task<IReadOnlyCollection<Category>> GetCategoriesAsync()
        {
           return await _categoryRepository.GetAllAsync();
        }
        public async Task<IReadOnlyCollection<Category>> GetMainCategoriesAsync()
        {
            return await _categoryRepository.FindByConditioAsync(x=>x.IsMainCategory);
        }
       
    }
}
