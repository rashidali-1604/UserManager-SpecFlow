using UserManager.SpecFlow.Api.Messages.Requests;
using UserManager.SpecFlow.Api.Models;
using UserManager.SpecFlow.Api.Repositories.Interfaces;
using UserManager.SpecFlow.Api.Services.Interfaces;

namespace UserManager.SpecFlow.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int CreateUser(CreateUserRequest request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress
            };

            return _userRepository.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);

            if (user == null)
            {
                return;
            }

            _userRepository.DeleteUser(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public void UpdateUser(UpdateUserRequest request)
        {
            var user = GetUserById(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User not found with Id : {request.Id}");
            }

            user.FirstName = request.FirstName ?? user.FirstName;
            user.LastName = request.LastName ?? user.LastName;
            user.EmailAddress = request.EmailAddress ?? user.EmailAddress;

            _userRepository.UpdateUser(user);
        }
    }
}