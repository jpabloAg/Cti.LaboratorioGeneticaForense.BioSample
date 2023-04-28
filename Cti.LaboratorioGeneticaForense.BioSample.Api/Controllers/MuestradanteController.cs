using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Commands.CreateMuestradante;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Queries.GetMuestradantesBySimilarityName;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cti.LaboratorioGeneticaForense.BioSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuestradanteController : ControllerBase
    {
        private readonly ISender _sender;
        public MuestradanteController(ISender sender) =>
            _sender = sender;

        [HttpPost]
        public async Task<Guid> RegisterMuestradante([FromBody] CreateMuestradanteCommand request)
        {
            var result = await _sender.Send(request);
            return result;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetMuestradante([FromBody] GetMuestradanteBySimilarityNameQuery request)
        {
            var result = await _sender.Send(request);
            return Ok(result);
        }
    }
}
