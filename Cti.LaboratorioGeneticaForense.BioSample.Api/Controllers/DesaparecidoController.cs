using Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Commands;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Queries;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrator")]
        public async Task<ApiResponse<Guid>> RegisterDesaparecido([FromBody] CreateDesaparecidoCommand request)
        {
            var result = await _sender.Send(request);
            if (result == Guid.Empty)
            {
                return new ApiResponse<Guid>
                {
                    StatusCode = 400,
                    Data = Guid.Empty,
                    ErrorMessage = "Ya existe un desaparecido con identificacion " + request.documentoIdentidad
                };
            }

            return new ApiResponse<Guid>
            {
                StatusCode = 201,
                Data = result,
                ErrorMessage = null
            };
        }

        [HttpPost("filter")]
        [Authorize]
        public async Task<ApiResponse<IEnumerable<DesaparecidoDto>>> GetDesaparecidos([FromBody] GetDesaparecidoBySimilarityNameQuery request)
        {
            var result = await _sender.Send(request);

            if (result.Any())
            {
                return new ApiResponse<IEnumerable<DesaparecidoDto>>
                {
                    StatusCode = 200,
                    Data = result,
                    ErrorMessage = null
                };
            }

            return new ApiResponse<IEnumerable<DesaparecidoDto>>
            {
                StatusCode = 404,
                Data = result,
                ErrorMessage = "No se encontraron resultados para el filtro especificado"
            };
        }

        [HttpGet("muestras/{desaparecidoId}")]
        [Authorize]
        public ApiResponse<IEnumerable<Desaparecido>> GetDesaparecidosWithMuestras(Guid desaparecidoId)
        {
            var result = _desaparecidoRepository.GetMuestras(desaparecidoId);

            if (result.Any())
            {
                return new ApiResponse<IEnumerable<Desaparecido>>
                {
                    StatusCode = 200,
                    Data = result,
                    ErrorMessage = null
                };
            }

            return new ApiResponse<IEnumerable<Desaparecido>>
            {
                StatusCode = 404,
                Data = result,
                ErrorMessage = "No se encontraron resultados para el filtro especificado"
            };
        }
    }
}
