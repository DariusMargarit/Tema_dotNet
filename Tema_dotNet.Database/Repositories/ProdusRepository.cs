using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Database.Repositories
{
    public class ProdusRepository
    {
        private readonly ProducatorManagementDBContext _context;

        public ProdusRepository(ProducatorManagementDBContext context)
        {
            _context = context;
        }

        public List<Produs> GetProduse()
        {
            var result = _context.Produse.ToList();
            return result;
        }
    }
}
