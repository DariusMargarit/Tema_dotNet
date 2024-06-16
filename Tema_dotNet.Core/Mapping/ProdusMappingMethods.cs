using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Dto.Request;
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

        public static List<ProdusResponseDto> MapProdusToProdusResponseDtoList(this List<Produs> produse)
        {
            List<ProdusResponseDto> result = new List<ProdusResponseDto>();
            foreach (var produs in produse)
            {
                result.Add(produs.MapProdusToProdusResponseDto());
            }
            return result;
        }

        public static Produs ToEntity(this AddProdusRequestDto addProdusRequestDto)
        {
            if (addProdusRequestDto == null)
            {
                return null;
            }

            return new Produs
            {
                Id = addProdusRequestDto.Id ?? 0,
                Nume = addProdusRequestDto.Nume,
                Pret = addProdusRequestDto.Pret,
                ProducatorId = addProdusRequestDto.ProducatorId
            };
        }

        public static Produs ToEntity(this EditProdusRequestDto editProdusRequestDto)
        {
            if (editProdusRequestDto == null)
            {
                return null;
            }

            return new Produs
            {
                Nume = editProdusRequestDto.Nume,
                Pret = editProdusRequestDto.Pret,
                ProducatorId = editProdusRequestDto.ProducatorId
            };
        }
    }
}
