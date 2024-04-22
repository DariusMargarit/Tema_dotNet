using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Database.Repositories;
using Tema_dotNet.Core.Dto.Response;
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
            return result.MapToProductResponseDtoList();
        }
    }
}
