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
                .Include(x => x.UserInfo)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<User>> FindByConditioAsync(Expression<Func<User, bool>> predicat)
        {
            return await Entities
               .Include(x => x.Customer)
               .Include(x => x.Employee)
               .Include(x => x.UserInfo)
               .Where(predicat)
               .ToListAsync()
               .ConfigureAwait(false);
        }
    }
}
