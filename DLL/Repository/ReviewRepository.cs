using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(FreelanserContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<Review>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.Customer)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Worker)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Review>> FindByConditioAsync(Expression<Func<Review, bool>> predicat)
        {
            return await Entities
                .Include(x => x.Customer)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Worker)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
