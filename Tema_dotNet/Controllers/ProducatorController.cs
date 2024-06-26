using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Services;

namespace Tema_dotNet.Controllers
{
    [Authorize(Roles = "User,Admin")]
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

        [HttpPost]
        [Route("add")]
        public IActionResult AddProducatori([FromBody] AddProducatorRequestDto payload)
        {
            try
            {
                _producatorService.AddProducator(payload);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();

        }

        [HttpPut]
        [Route("{producatorId}/update")]
        public IActionResult EditProducator([FromRoute] int producatorId, [FromBody] EditProducatorRequestDto payload)
        {
            try
            {
                _producatorService.EditProducator(producatorId, payload);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("delete-producator")]
        public IActionResult DeleteProducator([FromQuery] int produsId)
        {
            try
            {
                _producatorService.DeleteProducator(produsId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
