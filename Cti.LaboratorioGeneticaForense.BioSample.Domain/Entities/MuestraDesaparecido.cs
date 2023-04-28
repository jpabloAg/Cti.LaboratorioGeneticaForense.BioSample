namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities; 

public sealed class MuestraDesaparecido
{
    public Guid MuestraId { get; set; }
    public Guid DesaparecidoId { get; set; }
    public Muestra Muestra { get; set; }
    public Desaparecido Desaparecido { get; set; }
}
