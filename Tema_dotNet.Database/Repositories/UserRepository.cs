using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tema_dotNet.Database.Repositories
{
    public class UserRepository 
    {
        private readonly ProducatorManagementDBContext _context;

        public UserRepository(ProducatorManagementDBContext context)
        {
            _context = context;

        }

        public void Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception("Email already exists");
            }

            (_context).Users.Add(user);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users
                                        .Where(u => u.Email == email)
                                        .Include(u => u.Rol)
                                        .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public List<User> GetAll()
        {
            return _context.Users
                                    .Include(u => u.Rol)
                                    .ToList();
        }

        public User Get(int id)
        {
            var user = _context.Users
                                        .Where(u => u.Id == id)
                                        .Include(u => u.Rol)
                                        .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void Update(int id, User updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var role = _context.Roles.Find(updatedUser.RolId);
            if (role == null)
            {
                throw new Exception("Rol not found");
            }

            if (_context.Users.Any(u => u.Email == updatedUser.Email && u.Email != user.Email))
            {
                throw new Exception("Email already exists");
            }

            user.Nume = updatedUser.Nume;
            user.Email = updatedUser.Email;
            user.Parola = updatedUser.Parola;
            user.RolId = updatedUser.RolId;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
