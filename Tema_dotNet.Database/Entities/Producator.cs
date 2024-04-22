using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_dotNet.Database.Entities
{
    public class Producator
    {
        public int Id { get; set; }

        public string Nume { get; set; }

        public List<Produs> Produse { get; set; }
    }
}
