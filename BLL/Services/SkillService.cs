using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SkillService:ISkillService
    {
        private readonly SkillRepository _skillRepository;
        public SkillService(SkillRepository repository)
        {
            this._skillRepository = repository;
        }
        public async Task<IReadOnlyCollection<Skill>> GetSkillsAsync()
        {
            return await (_skillRepository as BaseRepository<Skill>).GetAllAsync();
        }
        public async Task<List<Skill>> GetSkillsWithWorkerAsync()
        {
            return (await _skillRepository.GetAllAsync()).ToList();
        }
        public async Task<bool> AddSkillAsync(Skill skill)
        {
            var oper=await _skillRepository.CreateAsync(skill);
            return oper.IsCompleted;
        }

        public Task<IReadOnlyCollection<Skill>> FindByConditionAsync(Expression<Func<Skill, bool>> prediacte)
        => _skillRepository.FindByConditioAsync(prediacte);
    }
}
