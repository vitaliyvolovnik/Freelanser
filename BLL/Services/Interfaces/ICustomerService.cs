using DLL;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IReadOnlyCollection<Customer>> FindByCustomerConditiomAsync(Expression<Func<Customer, bool>> prediacte);
        
        public Task<OperationDetail> PublishWorkAsync(Work work);
        public Task<bool> CanselWorkAsync(Customer customer,int workId);
        public Task ChangeWorkAsync(Work work,int oldId);
    }
}
