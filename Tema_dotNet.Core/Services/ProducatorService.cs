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
            try
            {
                var producator = payload.ToEntity();
                _producatorRepository.Add(producator);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       
        

        public void EditProducator(int producatorId, EditProducatorRequestDto payload)
        {
            try
            {
                var producator = _producatorRepository.GetById(producatorId);

                producator.Nume = payload.Nume;
                _producatorRepository.Update(producator);
            }
            catch (Exception e)
            {
               
                throw new Exception(e.Message);
            }
            
        }

        public void DeleteProducator(int producatorId)
        {
            try
            {
                var producator = _producatorRepository.GetById(producatorId);

                _producatorRepository.Delete(producator);
            }
            catch (Exception e)
            {
               
                throw new Exception(e.Message);
            }
            
        }
    }
}
