using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Commands.CreateMuestradante;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Queries.GetMuestradantesBySimilarityName;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrator")]
        public async Task<ApiResponse<Guid>> RegisterMuestradante([FromBody] CreateMuestradanteCommand request)
        {
            var result = await _sender.Send(request);

            if(result == Guid.Empty)
            {
                return new ApiResponse<Guid>
                {
                    StatusCode = 400,
                    Data = Guid.Empty,
                    ErrorMessage = "Ya existe un muestradante con identificacion " + request.documentoIdentidad
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
        public async Task<ApiResponse<IEnumerable<MuestradanteDto>>> GetMuestradante([FromBody] GetMuestradanteBySimilarityNameQuery request)
        {
            var result = await _sender.Send(request);

            if (result.Any())
            {
                return new ApiResponse<IEnumerable<MuestradanteDto>>
                {
                    StatusCode = 200,
                    Data = result,
                    ErrorMessage = null
                };
            }

            return new ApiResponse<IEnumerable<MuestradanteDto>>
            {
                StatusCode = 404,
                Data = result,
                ErrorMessage = "No se encontraron resultados para el filtro especificado"
            };
        }

        [HttpGet("identificacion/{identificacion}")]
        [Authorize]
        public async Task<ApiResponse<MuestradanteDto>> GetMuestradanteByIdentificacion(string identificacion)
        {
            var result = await _muestradanteRepository.GetByDocumentoIdentidadAsync(identificacion);

            if(result is not null)
            {
                return new ApiResponse<MuestradanteDto>
                {
                    StatusCode = 200,
                    Data = new MuestradanteDto
                    {
                        Id = result.Id,
                        Nombre = result.Nombre,
                        DocumentoIdentidad = result.DocumentoIdentidad,
                        PrimerApellido = result.PrimerApellido,
                        SegundoApellido = result.SegundoApellido,
                        Direccion = result.Direccion,
                        FechaNacimiento = result.FechaNacimiento,
                        Parentesco = result.Parentesco,
                        Telefono = result.Telefono,
                        Departamento = result.LugarNacimiento.Departamento,
                        Municipio = result.LugarNacimiento.Municipio,
                        TipoDocumento = result.TipoDocumento
                    },
                    ErrorMessage = null
                };
            }

            return new ApiResponse<MuestradanteDto>
            {
                StatusCode = 404,
                Data = null,
                ErrorMessage = "No se encontraron resultados para el filtro especificado"
            };
        }

        [HttpGet("/{id}")]
        [Authorize]
        public async Task<ApiResponse<MuestradanteDto>> GetMuestradanteById(Guid id)
        {
            var result = await _muestradanteRepository.GetByIdAsync(id);
            if (result is not null)
            {
                return new ApiResponse<MuestradanteDto>
                {
                    StatusCode = 200,
                    Data = new MuestradanteDto
                    {
                        Id = result.Id,
                        Nombre = result.Nombre,
                        DocumentoIdentidad = result.DocumentoIdentidad,
                        PrimerApellido = result.PrimerApellido,
                        SegundoApellido = result.SegundoApellido,
                        Direccion = result.Direccion,
                        FechaNacimiento = result.FechaNacimiento,
                        Parentesco = result.Parentesco,
                        Telefono = result.Telefono,
                        Departamento = result.LugarNacimiento.Departamento,
                        Municipio = result.LugarNacimiento.Municipio,
                        TipoDocumento = result.TipoDocumento
                    },
                    ErrorMessage = null
                };
            }

            return new ApiResponse<MuestradanteDto>
            {
                StatusCode = 404,
                Data = null,
                ErrorMessage = "No se encontraron resultados para el filtro especificado"
            };
        }

        [HttpGet("muestra/{muestradanteId}")]
        [Authorize]
        public async Task<Muestradante> GetMuestradantes(Guid muestradanteId)
        {
            return await _muestradanteRepository.GetMuestra(muestradanteId);
        }
    }
}
