using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestras.Commands.CreateMuestra
{
    public sealed record CreateMuestraCommand(
        string radicadoInterno,
        string tipoMuestra,
        string municipio,
        string departamento,
        string estadoMuestra,
        DateTime fechaTomaMuestra,
        DateTime fechaLlegadaLaboratorio,
        bool consentimientoPoblacional,
        string documentoIdentidadMuestradante) : IRequest<Guid>;
}
