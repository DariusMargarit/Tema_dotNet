using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Database.Repositories
{
    public class ProducatorRepository
    {
        private readonly ProducatorManagementDBContext _context;

        public ProducatorRepository(ProducatorManagementDBContext context)
        {
            _context = context;
        }

        public List<Producator> GetProducatori()
        {
            var result = _context.Producatori.Include(p => p.Produse).ToList();
            return result;
        }

        public void Add(Producator producator)
        {
            _context.Producatori.Add(producator);
            _context.SaveChanges();
        }
    }
}
