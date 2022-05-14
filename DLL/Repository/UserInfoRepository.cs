using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    internal class UserInfoRepository : BaseRepository<UserInfo>
    {
        public UserInfoRepository(FreelanserContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<UserInfo>> FindByConditioAsync(Expression<Func<UserInfo, bool>> predicat)
        {
            return await Entities
                .Include(x => x.User)
                .Where(predicat)
                .ToArrayAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<UserInfo>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.User)
                .ToArrayAsync()
                .ConfigureAwait(false);
        }
    }
}
