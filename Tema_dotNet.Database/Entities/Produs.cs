using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_dotNet.Database.Entities
{
    public class Produs
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public int Pret { get; set; }
        
        public int ProducatorId { get; set; }
        public Producator Producator { get; set; }
    }
}
