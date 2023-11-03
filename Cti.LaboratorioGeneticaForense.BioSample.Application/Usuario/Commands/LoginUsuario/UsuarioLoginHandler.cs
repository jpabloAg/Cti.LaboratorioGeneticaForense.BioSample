using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Usuario.Commands.LoginUsuario
{
    public sealed class UsuarioLoginHandler : IRequestHandler<UsuarioLogin, UsuarioLoginDto>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public UsuarioLoginHandler(
            IUsuarioRepository usuarioRepository,
            IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<UsuarioLoginDto> Handle(UsuarioLogin request, CancellationToken cancellationToken)
        {
            var usuario = await Authenticate(request);
            if (usuario is not null) {
                string token = Generate(usuario);
                return new UsuarioLoginDto
                {
                    Id = usuario.Id,
                    token = token,
                    Username = usuario.Username,
                    EmailAddress = usuario.EmailAddress,
                    GivenName = usuario.GivenName,
                    Role = usuario.Role,
                    Surname = usuario.Surname
                };
            }
            return null;
        }

        private async Task<Domain.Entities.Usuario> Authenticate(UsuarioLogin request)
        {
            var usuario = await _usuarioRepository.GetUsurio(request.EmailAddress, request.Password);
            return usuario;
        }

        private string Generate(Domain.Entities.Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Username),
                new Claim(ClaimTypes.Email, usuario.EmailAddress),
                new Claim(ClaimTypes.GivenName, usuario.GivenName),
                new Claim(ClaimTypes.Surname, usuario.Surname),
                new Claim(ClaimTypes.Role, usuario.Role)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
