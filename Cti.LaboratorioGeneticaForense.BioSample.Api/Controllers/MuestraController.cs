using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestras.Commands.CreateMuestra;
using Cti.LaboratorioGeneticaForense.BioSample.Application.MuestrasDesaparecidos.Commands;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cti.LaboratorioGeneticaForense.BioSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuestraController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ApplicationDbContext _dbcontext;
        public MuestraController(ISender sender, ApplicationDbContext dbcontext)
        {
            _sender = sender;
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<Guid> RegisterMuestra([FromBody] CreateMuestraCommand request)
        {
            var result = await _sender.Send(request);
            return result;
        }

        [HttpPost("vincular")]
        [Authorize(Roles = "Administrator")]
        public async Task<MuestraDesaparecido> VincularMuestraDesaparecido([FromBody] MuestraDesaparecidoCommand request)
        {
            var result = await _sender.Send(request);
            return result;
        }

        [HttpGet("total")]
        [Authorize]
        public ActionResult getTotalRegistros()
        {
            var result = new
            {
                TotalMuestradantes = _dbcontext.Set<Muestradante>().Count(),
                TotalDesaparecidos = _dbcontext.Set<Desaparecido>().Count(),
                TotalMuestras = _dbcontext.Set<Muestra>().Count(),
            };
            return Ok(result);
        }
    }
}
