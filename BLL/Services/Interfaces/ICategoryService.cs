using DLL;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IReadOnlyCollection<Category>> GetCategoriesAsync();
        Task<IReadOnlyCollection<Category>> GetMainCategoriesAsync();
        Task<IReadOnlyCollection<Category>> FindByConditionAsync(Expression<Func<Category,bool>> prediacte);
        Task<IReadOnlyCollection<Category>> FindByNameAsync(string name);
        Task<Category> FindParentCategoryAsync(string name);
        Task<OperationDetail> AddCategoryAsync(Category category);
    }
}
