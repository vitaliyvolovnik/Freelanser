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
                .ThenInclude(x=>x.Reviews)
                .Include(x=>x.Employee)
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
               .ThenInclude(x => x.Reviews)
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
               .ThenInclude(x => x.ProgectFiles)
               .Include(x => x.Customer)
               .ThenInclude(x => x.Work)
               .ThenInclude(x=>x.Skills)
               .Include(x => x.Employee)
               .ThenInclude(x => x.Reviews)
               .ThenInclude(x=>x.Customer)
               .ThenInclude(x=>x.User)
               .ThenInclude(x=>x.UserInfo)
               .Include(x => x.Employee)
               .ThenInclude(x => x.Skills)
               .Include(x=>x.Employee)
               .ThenInclude(x=>x.ExecutedWorks)
               .ThenInclude(x=>x.ProgectFiles)
               .Include(x => x.Employee)
               .ThenInclude(x => x.ExecutedWorks)
               .ThenInclude(x=>x.Skills)
               .Include(x => x.UserInfo)
               .Where(predicat)
               .ToListAsync()
               .ConfigureAwait(false);
        }
        public async Task EditInfo(User editUser)
        {
            var user = await Entities.FindAsync(editUser.Id);
            user.UserInfo.Name = editUser.UserInfo.Name;
            user.UserInfo.Surname = editUser.UserInfo.Surname;
            user.UserInfo.Information = editUser.UserInfo.Information;
            user.UserInfo.Phone = editUser.UserInfo.Phone;
            if (user.IsWorker)
            {
                user.Employee.Skills = editUser.Employee.Skills;
            }
            
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

    }
}
