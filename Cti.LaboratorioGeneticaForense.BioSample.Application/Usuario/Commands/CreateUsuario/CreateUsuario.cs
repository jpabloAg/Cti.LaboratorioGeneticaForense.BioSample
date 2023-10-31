using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Usuario.Commands.CreateUsuario
{
    public sealed record CreateUsuario
        (
            string Username,
            string Password,
            string EmailAddress,
            string Role,
            string Surname,
            string GivenName
        ) : IRequest<Guid>;
}
