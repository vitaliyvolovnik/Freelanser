﻿using BLL.Services.Interfaces;
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
    public class UserService : ICustomerService, IEmployeeService, IUserService, IUserInfoService, IReviewService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly UserRepository _userRepository;
        private readonly WorkRepository _workRepository;
        private readonly UserInfoRepository _userInfoRepository;
        private readonly ReviewRepository _reviewRepository;

        public UserService(EmployeeRepository employeeRepository,
            CustomerRepository customerRepository,
            UserRepository userRepository,
            WorkRepository workRepository,
            UserInfoRepository userInfoRepository,
            ReviewRepository reviewRepository)
        {
            this._employeeRepository = employeeRepository;
            this._customerRepository = customerRepository;
            this._userRepository = userRepository;
            this._workRepository = workRepository;
            this._userInfoRepository = userInfoRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> CanselWorkAsync(Customer customer, int workId)
        {
            return await _workRepository.CanselWorkAsync(customer.Id, workId);

        }
        public async Task ChangeWorkAsync(Work work, int oldId)
        => await _workRepository.UpdateAsync(oldId, work);
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
            return await _workRepository.TakeWorkAsync(workId, employeeId);
        }
        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        => (await this._employeeRepository.FindByConditioAsync(x => x.Id == employeeId))?.First();
        public async Task<User> GetUserByEmailAsync(string email)
       => (await this._userRepository.FindByConditioAsync(x => x.Email == email))?.First();
        public async Task<Customer> GetCstomerByIdAsync(int id)
        => (await this._customerRepository.FindByConditioAsync(x => x.Id == id))?.First();
        public async Task ChangePhotoAsync(int userinfoId, string path)
        {
            await this._userInfoRepository.ChangePhoto(userinfoId, path);
        }
        public async Task<User> GetUserByEmailWithWorksAsync(string email)
        => (await this._userRepository.FindByConditioWithWorksAsync(x => x.Email == email))?.First();
        public async Task EditInfoAsync(User user)
        => await _userRepository.EditInfo(user);
        public async Task<IReadOnlyCollection<Employee>> GetEmployeesBySkillCategoryesAsync(Category category)
        {
            
            if (!category.IsMainCategory)
                return (await _employeeRepository.FindByConditioAsync(x => x.Skills.Any(y => y.Category.Name == category.Name))).ToList();
            return (await _employeeRepository.FindByConditioAsync(x => x.Skills.Any(y=>y.Category.CategoryId == category.Id))).ToList();
        }

        public async Task AddReviewAsync(Review review)
        {
            await this._reviewRepository.CreateAsync(review);
        }
    }
}
