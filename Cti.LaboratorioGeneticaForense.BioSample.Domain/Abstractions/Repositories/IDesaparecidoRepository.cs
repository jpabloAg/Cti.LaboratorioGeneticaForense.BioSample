using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;

public interface IDesaparecidoRepository
{
    void Add(Desaparecido desaparecido);
    IEnumerable<Desaparecido> GetAll(IEnumerable<Guid> Ids);
}