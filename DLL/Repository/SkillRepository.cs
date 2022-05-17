using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class SkillRepository : BaseRepository<Skill>
    {
        public SkillRepository(FreelanserContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<Skill>> FindByConditioAsync(Expression<Func<Skill, bool>> predicat)
        {
            return await Entities
                .Include(x => x.Employees)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Skill>> GetAllAsync()
        {
            return await Entities
               .Include(x => x.Employees)
               .ToListAsync()
               .ConfigureAwait(false);
        }
    }
}
