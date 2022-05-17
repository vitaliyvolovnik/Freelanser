using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> TakeWorkAsync(int employeeId, int workId);
        Task<IReadOnlyCollection<Employee>> GetAllEmployeesAsync();
        Task<List<Employee>> GetAllEmployeesWithSkillsAsync(List<Skill> skills);
        Task<IReadOnlyCollection<Employee>> FindEmployeeByConditiomAsync(Expression<Func<Employee, bool>> prediacte);
    }
}
