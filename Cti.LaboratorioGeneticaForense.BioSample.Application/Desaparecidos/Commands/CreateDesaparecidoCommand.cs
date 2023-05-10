using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Commands;

public sealed record CreateDesaparecidoCommand(
    string nombre,
    string primerApellido,
    string segundoApellido,
    string documentoIdentidad,
    string tipoDocumento,
    string genero,
    string sirdec,
    string lugarNacimientoMunicipio,
    string lugarNacimientoDepartamento,
    string lugarTomaCuerpoMunicipio,
    string lugarTomaCuerpoDepartamento) : IRequest<Guid>;
