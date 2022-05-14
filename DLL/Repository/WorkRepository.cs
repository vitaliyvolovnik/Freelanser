using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class WorkRepository : BaseRepository<Work>
    {
        public WorkRepository(FreelanserContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<Work>> FindByConditioAsync(Expression<Func<Work, bool>> predicat)
        {
            return await Entities
                .Include(x => x.Customer)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Worker)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Files)
                .Include(x => x.Coments)
                .Include(x => x.Categories)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Work>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.Customer)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Worker)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Files)
                .Include(x => x.Coments)
                .Include(x => x.Categories)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
