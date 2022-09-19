using UserManager.SpecFlow.Api.Models;

namespace UserManager.SpecFlow.Api.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetUsers();

        int CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);
    }
}