using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(FreelanserContext context) : base(context)
        {

        }

        public async Task<IReadOnlyCollection<Skill>> GetSkillsWithEmployeeAsync()
        {
            return await Entities
                .Include(x => x.Employees)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
