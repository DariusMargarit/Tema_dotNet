using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Tema_dotNet.Database.Entities;
using Tema_dotNet.Database.Repositories;

namespace Tema_dotNet.Database.Repositories
{
    public class RolRepository 
    {
        private readonly ProducatorManagementDBContext _context;
        public RolRepository(ProducatorManagementDBContext context) 
        {
            _context = context;
        }

        public List<Rol> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Rol Get(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                throw new Exception("Rol not found");
            }
            return role;
        }

        public void Create(Rol rol)
        {
            if (_context.Roles.Any(r => r.Nume == rol.Nume))
            {
                throw new Exception($"Rol with name {rol.Nume} already exists");
            }
            _context.Roles.Add(rol);
            _context.SaveChanges();
        }

        public void Update(int id, Rol updatedRol)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                throw new Exception("Rol not found");
            }

            if (_context.Roles.Any(r => r.Nume == updatedRol.Nume && r.Nume != role.Nume))
            {
                throw new Exception($"Rol with name {updatedRol.Nume} already exists");
            }

            role.Nume = updatedRol.Nume;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _context.Roles
                                        .Where(r => r.Id == id)
                                        .Include(r => r.Users)
                                        .FirstOrDefault();
            if (role == null)
            {
                throw new Exception("Rol not found");
            }

            if (role.Users.Count > 0)
            {
                throw new Exception("Rol has users assigned to it and can't be deleted");
            }

            _context.Roles.Remove(role); 
            _context.SaveChanges();
        }
    }
}
