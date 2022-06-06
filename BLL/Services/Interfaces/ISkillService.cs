using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IReadOnlyCollection<Skill>> GetSkillsAsync();
        Task<List<Skill>> GetSkillsWithWorkerAsync();
        Task<bool> AddSkillAsync(Skill skill);
        Task<IReadOnlyCollection<Skill>> FindByConditionAsync(Expression<Func<Skill, bool>> prediacte);
        Task<IReadOnlyCollection<Skill>> GetSkillsbyNamesAsync(List<string> Skillname);
    }
}
