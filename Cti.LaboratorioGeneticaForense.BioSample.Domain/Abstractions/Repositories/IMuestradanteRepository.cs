using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;

public interface IMuestradanteRepository
{
    void Add(Muestradante muestradante);
    Task<Muestradante?> GetByIdAsync(string documentoIdentidad);
}
