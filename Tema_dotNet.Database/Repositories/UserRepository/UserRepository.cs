using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tema_dotNet.Database.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ProducatorManagementDBContext producatorManagementDBContext) : base(producatorManagementDBContext)
        {
        }

        public void Register(User user)
        {
            if (_producatorManagementDbContext.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception("Email already exists");
            }

            (_producatorManagementDbContext).Users.Add(user);
            SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var user = _producatorManagementDbContext.Users
                                        .Where(u => u.Email == email)
                                        .Include(u => u.Role)
                                        .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public List<User> GetAll()
        {
            return _producatorManagementDbContext.Users
                                    .Include(u => u.Role)
                                    .ToList();
        }

        public User Get(int id)
        {
            var user = _producatorManagementDbContext.Users
                                        .Where(u => u.Id == id)
                                        .Include(u => u.Role)
                                        .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void Update(int id, User updatedUser)
        {
            var user = _producatorManagementDbContext.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var role = _producatorManagementDbContext.Roles.Find(updatedUser.RoleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            if (_producatorManagementDbContext.Users.Any(u => u.Email == updatedUser.Email && u.Email != user.Email))
            {
                throw new Exception("Email already exists");
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            user.RoleId = updatedUser.RoleId;

            SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _producatorManagementDbContext.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _producatorManagementDbContext.Users.Remove(user);
            SaveChanges();
        }
    }
}
