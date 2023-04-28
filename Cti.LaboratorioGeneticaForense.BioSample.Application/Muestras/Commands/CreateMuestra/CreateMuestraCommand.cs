using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestras.Commands.CreateMuestra
{
    public sealed record CreateMuestraCommand(
        string radicadoInterno,
        TipoMuestra tipoMuestra,
        string municipio,
        string departamento,
        EstadoMuestra estadoMuestra,
        DateTime fechaTomaMuestra,
        DateTime fechaLlegadaLaboratorio,
        bool consentimientoPoblacional,
        string documentoIdentidadMuestradante) : IRequest<Guid>;
}
