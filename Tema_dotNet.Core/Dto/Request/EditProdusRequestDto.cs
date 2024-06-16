using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_dotNet.Core.Dto.Request
{
    public class EditProdusRequestDto
    {
        public string Nume { get; set; }
        public int Pret { get; set; }
        public int ProducatorId { get; set; }
    }
}
