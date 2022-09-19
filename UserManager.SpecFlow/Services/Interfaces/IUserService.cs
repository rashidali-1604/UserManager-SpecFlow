using UserManager.SpecFlow.Api.Messages.Requests;
using UserManager.SpecFlow.Api.Models;

namespace UserManager.SpecFlow.Api.Services.Interfaces
{
    public interface IUserService
    {
        int CreateUser(CreateUserRequest request);

        void UpdateUser(UpdateUserRequest request);

        User GetUserById(int userId);

        IEnumerable<User> GetAll();
        void DeleteUser(int id);
    }
}