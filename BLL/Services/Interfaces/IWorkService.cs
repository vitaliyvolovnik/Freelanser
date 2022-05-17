using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IWorkService
    {

        Task<IReadOnlyCollection<Work>> GetWorksAsync();
        Task<List<Work>> GetWorksWithUsersAsync();
        Task<List<Work>> GetWorksByCategorysAsync(List<Category> categories);
        Task<IReadOnlyCollection<Work>> FindByConditionAsync(Expression<Func<Work, bool>> prediacte);
        Task<Work> GetWorkByIdAsync(int id);
        Task<bool> AddComentAsync(Comment comment, int WorkId);
    }
}
