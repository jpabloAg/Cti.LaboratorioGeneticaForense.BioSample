using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestras.Commands.CreateMuestra;
using Cti.LaboratorioGeneticaForense.BioSample.Application.MuestrasDesaparecidos.Commands;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cti.LaboratorioGeneticaForense.BioSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuestraController : ControllerBase
    {
        private readonly ISender _sender;
        public MuestraController(ISender sender) =>
            _sender = sender;

        [HttpPost]
        public async Task<Guid> RegisterMuestra([FromBody] CreateMuestraCommand request)
        {
            var result = await _sender.Send(request);
            return result;
        }

        [HttpPost("vincular")]
        public async Task<MuestraDesaparecido> VincularMuestraDesaparecido([FromBody] MuestraDesaparecidoCommand request)
        {
            var result = await _sender.Send(request);
            return result;
        }
    }
}
