using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Database.Repositories;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Mapping;

namespace Tema_dotNet.Core.Services
{
    public class ProducatorService
    {
        private readonly ProducatorRepository _producatorRepository;

        public ProducatorService(ProducatorRepository producatorRepository)
        {
            _producatorRepository = producatorRepository;
        }

        public List<ProducatorResponseDto> GetProducatori()
        {
            var result = _producatorRepository.GetProducatori();
            return result.MapToProducatorResponseDtoList();
        }

        public void AddProducator(AddProducatorRequestDto payload)
        {
            var producator = payload.ToEntity();
            _producatorRepository.Add(producator);
        }

        public void EditProducator(int producatorId, EditProducatorRequestDto payload)
        {
            var producator = _producatorRepository.GetById(producatorId);
            if (producator == null)
            {
                throw new Exception("Producator not found");
            }
            producator.Nume = payload.Nume;
            _producatorRepository.Update(producator);
        }

        public void DeleteProducator(int producatorId)
        {
            var producator = _producatorRepository.GetById(producatorId);
            if (producator == null)
            {
                throw new Exception("Producator not found");
            }
            _producatorRepository.Delete(producator);
        }
    }
}
