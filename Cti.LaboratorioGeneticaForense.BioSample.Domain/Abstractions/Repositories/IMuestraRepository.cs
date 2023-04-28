using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;

public interface IMuestraRepository
{
    void Add(Muestra muestra);

    Task<bool> ExistsMuestra(Guid muestradanteId);
}