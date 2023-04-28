using Cti.LaboratorioGeneticaForense.BioSample.Domain.Primitives;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;

public class Region
{
    public Region(string departamento, string municipio)
    {
        Departamento = departamento;
        Municipio = municipio;
    }
    public string Departamento { get; private set; }
    public string Municipio { get; private set; }
}
