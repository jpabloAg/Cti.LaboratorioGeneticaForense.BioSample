using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Commands;

public sealed record CreateDesaparecidoCommand(
    string nombre,
    string primerApellido,
    string segundoApellido,
    string documentoIdentidad,
    TipoDocumento tipoDocumento,
    Genero genero,
    string sirdec,
    string lugarNacimientoMunicipio,
    string lugarNacimientoDepartamento,
    string lugarTomaCuerpoMunicipio,
    string lugarTomaCuerpoDepartamento) : IRequest<Guid>;
