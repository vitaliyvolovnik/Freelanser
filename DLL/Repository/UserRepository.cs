using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(FreelanserContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .ThenInclude(x => x.Skills)
                .Include(x => x.UserInfo)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<User>> FindByConditioAsync(Expression<Func<User, bool>> predicat)
        {
            return await Entities
               .Include(x => x.Customer)
               .Include(x => x.Employee)
               .ThenInclude(x=>x.Skills)
               .Include(x => x.UserInfo)
               .Where(predicat)
               .ToListAsync()
               .ConfigureAwait(false);
        }
        public  async Task<IReadOnlyCollection<User>> FindByConditioWithWorksAsync(Expression<Func<User, bool>> predicat)
        {
            return await Entities
               .Include(x => x.Customer)
               .ThenInclude(x=>x.Work)
               .Include(x => x.Employee)
               .ThenInclude(x => x.Skills)
               .Include(x=>x.Employee)
               .ThenInclude(x=>x.ExecutedWorks)
               .Include(x => x.UserInfo)
               .Where(predicat)
               .ToListAsync()
               .ConfigureAwait(false);
        }

    }
}
