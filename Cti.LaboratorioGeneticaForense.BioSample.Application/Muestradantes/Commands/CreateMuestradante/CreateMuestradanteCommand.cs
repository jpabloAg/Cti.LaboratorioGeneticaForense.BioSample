using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Commands.CreateMuestradante;

public sealed record CreateMuestradanteCommand(
    string documentoIdentidad,
    string tipoDocumento,
    string nombre,
    string primerApellido,
    string? segundoApellido,
    string parentesco,
    DateTime fechaNacimiento,
    string municipio,
    string departamento,
    string? direccion,
    string? telefono,
    string? genero) : IRequest<Guid>;