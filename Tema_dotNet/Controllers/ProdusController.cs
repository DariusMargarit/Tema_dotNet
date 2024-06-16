using Microsoft.AspNetCore.Mvc;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Dto.Request;
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

        [HttpPost]
        [Route("add")]
        public IActionResult AddProdus([FromBody] AddProdusRequestDto payload)
        {
            _produsService.AddProdus(payload);
            return Ok();
        }

        [HttpPut]
        [Route("{produsId}/edit")]
        public IActionResult EditProdus([FromRoute] int produsId, [FromBody] EditProdusRequestDto payload)
        {
            try
            {
                _produsService.EditProdus(produsId, payload);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
