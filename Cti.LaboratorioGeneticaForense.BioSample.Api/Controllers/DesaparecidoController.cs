using Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Commands;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Queries;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cti.LaboratorioGeneticaForense.BioSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesaparecidoController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IDesaparecidoRepository _desaparecidoRepository;
        public DesaparecidoController(ISender sender, IDesaparecidoRepository desaparecidoRepository)
        {
            _sender = sender;
            _desaparecidoRepository = desaparecidoRepository;
        }
            

        [HttpPost]
        public async Task<Guid> RegisterDesaparecido([FromBody] CreateDesaparecidoCommand request)
        {
            var result = await _sender.Send(request);
            return result;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetMuestradante([FromBody] GetDesaparecidoBySimilarityNameQuery request)
        {
            var result = await _sender.Send(request);
            return Ok(result);
        }

        [HttpGet("muestras/{desaparecidoId}")]
        public IEnumerable<Desaparecido> GetMuestradantes(Guid desaparecidoId)
        {
            return _desaparecidoRepository.GetMuestras(desaparecidoId);
        }
    }
}
