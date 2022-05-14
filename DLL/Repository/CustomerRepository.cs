using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {

        public CustomerRepository(FreelanserContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<Customer>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Reviews)
                .Include(x => x.Work)
                .ToListAsync()
                .ConfigureAwait(false);

        }
        public override async Task<IReadOnlyCollection<Customer>> FindByConditioAsync(Expression<Func<Customer, bool>> predicat)
        {
            return await Entities
                .Include(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Reviews)
                .Include(x => x.Work)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }

    }
}
