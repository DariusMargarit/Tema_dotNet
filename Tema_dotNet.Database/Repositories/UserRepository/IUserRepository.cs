using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Database.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);

        User GetByEmail(string email);

        List<User> GetAll();

        User Get(int id);

        void Update(int id, User updatedUser);

        void Delete(int id);
    }
}