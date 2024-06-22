using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Tema_dotNet.Database.Entities;
using Tema_dotNet.Database.Repositories;

namespace Tema_dotNet.Database.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(ProducatorManagementDBContext context) : base(context)
        {
        }

        public List<Role> GetAll()
        {
            return _producatorManagementDbContext.Roles.ToList();
        }

        public Role Get(int id)
        {
            var role = _producatorManagementDbContext.Roles.Find(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            return role;
        }

        public void Create(Role role)
        {
            if (_producatorManagementDbContext.Roles.Any(r => r.Name == role.Name))
            {
                throw new Exception($"Role with name {role.Name} already exists");
            }
            _producatorManagementDbContext.Roles.Add(role);
            SaveChanges();
        }

        public void Update(int id, Role updatedRole)
        {
            var role = _producatorManagementDbContext.Roles.Find(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            if (_producatorManagementDbContext.Roles.Any(r => r.Name == updatedRole.Name && r.Name != role.Name))
            {
                throw new Exception($"Role with name {updatedRole.Name} already exists");
            }

            role.Name = updatedRole.Name;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _producatorManagementDbContext.Roles
                                        .Where(r => r.Id == id)
                                        .Include(r => r.Users)
                                        .FirstOrDefault();
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            if (role.Users.Count > 0)
            {
                throw new Exception("Role has users assigned to it and can't be deleted");
            }

            _producatorManagementDbContext.Roles.Remove(role);
            SaveChanges();
        }
    }
}
