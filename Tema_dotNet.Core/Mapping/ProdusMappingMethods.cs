using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Core.Mapping
{
    public static class ProdusMappingMethods
    {
        public static ProdusResponseDto MapProdusToProdusResponseDto(this Produs produs)
        {
            return new ProdusResponseDto
            {
                Id = produs.Id,
                Nume = produs.Nume,
                Pret = produs.Pret
            };
        }
    }
}
