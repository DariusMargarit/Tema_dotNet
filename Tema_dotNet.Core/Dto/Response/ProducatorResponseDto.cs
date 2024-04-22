using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_dotNet.Core.Dto.Response
{
    public class ProducatorResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProdusResponseDto> Produse { get; set; }
    }
}
