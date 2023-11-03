using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Usuario.Commands.LoginUsuario
{
    public sealed record UsuarioLogin
    (
        string EmailAddress,
        string Password
    ) : IRequest<UsuarioLoginDto>;
}
