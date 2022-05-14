using Domain.Models;

namespace DLL.Repository.Interfaces
{
    public interface ISkillRepository
    {
        public Task<IReadOnlyCollection<Skill>> GetSkillsWithEmployeeAsync();
    }
}
