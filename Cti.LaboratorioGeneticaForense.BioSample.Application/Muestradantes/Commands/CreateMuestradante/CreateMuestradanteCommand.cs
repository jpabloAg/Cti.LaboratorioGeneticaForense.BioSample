using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Commands.CreateMuestradante;

public sealed record CreateMuestradanteCommand(
    string documentoIdentidad,
    TipoDocumento tipoDocumento,
    string nombre,
    string primerApellido,
    string? segundoApellido,
    Parentesco parentesco,
    DateTime fechaNacimiento,
    string municipio,
    string departamento,
    string? direccion,
    string? telefono) : IRequest<Guid>;