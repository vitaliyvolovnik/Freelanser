using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(FreelanserContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<Employee>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.ExecutedWorks)
                .Include(x => x.Reviews)
                .ThenInclude(x=>x.Customer)
                .Include(x => x.Skills)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Employee>> FindByConditioAsync(Expression<Func<Employee, bool>> predicat)
        {
            return await Entities
                .Include(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.ExecutedWorks)
                .ThenInclude(x => x.Customer)
                .Include(x => x.Reviews)
                .ThenInclude(x=>x.Customer)
                .ThenInclude(x=>x.User)
                .ThenInclude(x=>x.UserInfo)
                .Include(x => x.Skills)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }

    }
}
