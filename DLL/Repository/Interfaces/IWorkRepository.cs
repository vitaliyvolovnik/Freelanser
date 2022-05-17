using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public interface IWorkRepository
    {
        Task<IReadOnlyCollection<Work>> GetAllWithUsersAsync();
        Task<IReadOnlyCollection<Work>> FindByConditioWithUsersAsync(Expression<Func<Work, bool>> predicat);
    }
}
