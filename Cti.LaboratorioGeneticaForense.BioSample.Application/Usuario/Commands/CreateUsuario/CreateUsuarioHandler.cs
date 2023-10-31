using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Usuario.Commands.CreateUsuario
{
    public sealed class CreateUsuarioHandler : IRequestHandler<CreateUsuario, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUsuarioHandler(
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUsuario request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetUsurio(request.EmailAddress, request.Password);

            if (usuario is not null)
            {
                return Guid.Empty;
            }

            var newUser = new Domain.Entities.Usuario
            {
                Id = Guid.NewGuid(),
                Username = request.EmailAddress,
                Password = request.Password,
                EmailAddress = request.EmailAddress,
                Role = request.Role,
                Surname = request.Surname,
                GivenName = request.GivenName
            };

            _usuarioRepository.Add(newUser);
            await _unitOfWork.SaveChangesAsync();

            return newUser.Id;
        }
    }
}
