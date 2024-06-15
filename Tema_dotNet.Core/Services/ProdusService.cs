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
    public class ProdusService
    {
        private readonly ProdusRepository _produsRepository;

        public ProdusService(ProdusRepository produsRepository)
        {
            _produsRepository = produsRepository;
        }

        public List<ProdusResponseDto> GetProduse()
        {
            var result = _produsRepository.GetProduse();
            return result.MapProdusToProdusResponseDtoList();
        }
    }
}
