using Amazon.Runtime.Internal;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Muestras.Commands.CreateMuestra;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Usuario.Commands.CreateUsuario;
using Cti.LaboratorioGeneticaForense.BioSample.Application.Usuario.Commands.LoginUsuario;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace Cti.LaboratorioGeneticaForense.BioSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ISender _sender;
        private IConfiguration _configuration;

        public UsuarioController(ISender sender, IConfiguration configuration)
        {
            _sender = sender;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<Guid> CrearUsuario([FromBody] CreateUsuario request)
        {
            var result = await _sender.Send(request);
            return result;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UsuarioLogin usuarioLogin)
        {
            var token = await _sender.Send(usuarioLogin);

            if (token != string.Empty)
            {
                return Ok(token);
            }

            return NotFound();
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            Usuario? user = GetCurrentUsuario();
            return Ok("Hi, you're on public property");
        }

        [HttpGet("auth")]
        [Authorize]
        public IActionResult AuthRequired()
        {
            var currentUser = GetCurrentUsuario();

            return Ok($"Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUsuario();

            return Ok($"[ADMIN] Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }


        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUsuario();

            return Ok($"[SELLER] Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        private Usuario GetCurrentUsuario()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new Usuario
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
