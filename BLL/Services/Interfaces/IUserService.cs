using Domain.Models;


namespace BLL.Services.Interfaces
{
    public interface IUserService
    {

        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByEmailWithWorksAsync(string email);
        
    }
}
