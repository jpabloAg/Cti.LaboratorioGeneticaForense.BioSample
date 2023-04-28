using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories
{
    public interface IAnexoRepository
    {
        void Add(Anexo anexo);
        Task<Anexo> GetById(Guid AnexoId);
    }
}
