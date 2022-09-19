using UserManager.SpecFlow.Api.Data;
using UserManager.SpecFlow.Api.Models;
using UserManager.SpecFlow.Api.Repositories.Interfaces;

namespace UserManager.SpecFlow.Api.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public int CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.AsEnumerable();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);

            _context.SaveChanges();
        }
    }
}