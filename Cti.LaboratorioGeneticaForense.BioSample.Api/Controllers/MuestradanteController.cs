using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Commands.CreateMuestradante;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Queries.GetMuestradantesBySimilarityName;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;
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
        private readonly IMuestradanteRepository _muestradanteRepository;
        public MuestradanteController(ISender sender, IMuestradanteRepository muestradanteRepository)
        {
            _sender = sender;
            _muestradanteRepository = muestradanteRepository;
        }

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

        [HttpGet("identificacion/{identificacion}")]
        public async Task<IActionResult> GetMuestradanteByIdentificacion(string identificacion)
        {
            var result = await _muestradanteRepository.GetByDocumentoIdentidadAsync(identificacion);
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetMuestradanteById(Guid id)
        {
            var result = await _muestradanteRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("muestra/{muestradanteId}")]
        public async Task<Muestradante> GetMuestradantes(Guid muestradanteId)
        {
            return await _muestradanteRepository.GetMuestra(muestradanteId);
        }
    }
}
