using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Database.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetAll();

        Role Get(int id);

        void Create(Role role);

        void Update(int id, Role updatedRole);

        void Delete(int id);
    }
}