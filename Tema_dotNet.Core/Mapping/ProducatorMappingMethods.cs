using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Core.Mapping
{
    public static class ProducatorMappingMethods
    {
        public static ProducatorResponseDto MapToProducatorResponseDto(this Producator producator)
        {
            var result = new ProducatorResponseDto();
            result.Id = producator.Id;
            result.Name = producator.Nume;
            List<ProdusResponseDto> produsResponseDtos = new List<ProdusResponseDto>();
            foreach (var produs in producator.Produse)
            {
                produsResponseDtos.Add(produs.MapProdusToProdusResponseDto());
            }
            result.Produse = produsResponseDtos;
            return result;
        }

        public static List<ProducatorResponseDto> MapToProducatorResponseDtoList(this List<Producator> producatori)
        {
            List<ProducatorResponseDto> result = new List<ProducatorResponseDto>();
            foreach (var producator in producatori)
            {
                result.Add(producator.MapToProducatorResponseDto());
            }
            return result;
        }

        public static Producator ToEntity(this AddProducatorRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            var result = new Producator();
            result.Nume = dto.Nume;
            return result;
        }

        public static Producator ToEntity(this EditProducatorRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            var result = new Producator();
            result.Nume = dto.Nume;
            return result;
        }
    }
}
