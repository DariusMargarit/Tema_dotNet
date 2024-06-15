using Microsoft.AspNetCore.Mvc;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Services;

namespace Tema_dotNet.Controllers
{
    [Route("api/produse")]
    public class ProdusController : ControllerBase
    {
        private readonly ProdusService _produsService;

        public ProdusController(ProdusService produsService)
        {
            _produsService = produsService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<ProdusResponseDto>> GetProduse()
        {
            var result = _produsService.GetProduse();
            return Ok(result);
        }
    }
}
