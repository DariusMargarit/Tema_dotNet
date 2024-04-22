using Microsoft.AspNetCore.Mvc;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Services;

namespace Tema_dotNet.Controllers
{
    [Route("api/producatori")]
    public class ProducatoriController : ControllerBase
    {
        private readonly ProducatorService _producatorService;

        public ProducatoriController(ProducatorService producatorService)
        {
            _producatorService = producatorService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<ProdusResponseDto>> GetProducatori()
        {
            var result = _producatorService.GetProducatori();
            return Ok(result);
        }
    }
}
