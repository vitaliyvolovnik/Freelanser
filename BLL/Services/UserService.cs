using BLL.Services.Interfaces;
using DLL;
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
    public class UserService : ICustomerService, IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomerRepository _customerRepository;
        //private readonly UserRepository _userRepository;
        private readonly WorkRepository _workRepository;

        public UserService(EmployeeRepository employeeRepository, CustomerRepository customerRepository, WorkRepository workRepository)
        {
            this._employeeRepository = employeeRepository;
            this._customerRepository = customerRepository;
            //this._userRepository = userRepository;
            this._workRepository = workRepository;
        }

        public async Task<bool> CanselWorkAsync(Customer customer, int workId)
        {
            return await _workRepository.CanselWork(customer.Id, workId);

        }
        public async Task ChangeWorkAsync(Work work, int oldId)
        =>await _workRepository.UpdateAsync(oldId, work); 
        public async Task<IReadOnlyCollection<Customer>> FindByCustomerConditiomAsync(Expression<Func<Customer, bool>> prediacte)
        => await _customerRepository.FindByConditioAsync(prediacte);
        public async Task<IReadOnlyCollection<Employee>> FindEmployeeByConditiomAsync(Expression<Func<Employee, bool>> prediacte)
        => await _employeeRepository.FindByConditioAsync(prediacte);
        public async Task<IReadOnlyCollection<Employee>> GetAllEmployeesAsync()
        {
            return await this._employeeRepository.GetAllAsync();
        }
        public async Task<List<Employee>> GetAllEmployeesWithSkillsAsync(List<Skill> skills)
        {
            return (await this._employeeRepository
                .FindByConditioAsync(x => x.Skills.Any(s => skills.Any(c => c.Name == s.Name)))).ToList();
        }
        public async Task<OperationDetail> PublishWorkAsync(Work work)
        {
            return await _workRepository.CreateAsync(work);
        }
        public async Task<bool> TakeWorkAsync(int employeeId, int workId)
        {
            return await _workRepository.TakeWork(workId, employeeId); 
        }
    }
}
