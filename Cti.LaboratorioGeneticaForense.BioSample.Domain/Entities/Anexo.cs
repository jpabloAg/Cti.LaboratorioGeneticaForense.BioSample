using Cti.LaboratorioGeneticaForense.BioSample.Domain.Primitives;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

public sealed class Anexo : Entity
{
    public string? OT { get; set; }
    public string? Perito { get; set; }
    public string? Observaciones { get; set; }
    public string? UriDocumentacion { get; set; }
    public Guid MuestraId { get; set; }
}