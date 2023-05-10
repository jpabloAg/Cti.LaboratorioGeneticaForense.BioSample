using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;

public interface IMuestradanteRepository
{
    void Add(Muestradante muestradante);
    Task<Muestradante?> GetByDocumentoIdentidadAsync(string documentoIdentidad);
    Task<Muestradante?> GetByIdAsync(Guid muestradanteId);
    Task<Muestradante?> GetMuestra(Guid muestradanteId);
}
