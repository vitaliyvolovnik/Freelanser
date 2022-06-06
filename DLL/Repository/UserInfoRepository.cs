using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class UserInfoRepository : BaseRepository<UserInfo>
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
        public async Task ChangePhoto(int id, string path)
        {
            var user = await Entities.FindAsync(id);
            if (user == null) return;
            user.PhotoPath = path;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }
    }
}
