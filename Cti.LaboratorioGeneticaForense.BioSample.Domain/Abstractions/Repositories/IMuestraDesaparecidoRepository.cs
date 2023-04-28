using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;

public interface IMuestraDesaparecidoRepository
{
    void VincularMuestraDesaparecido(MuestraDesaparecido muestraDesaparecido);
    Task<bool> ExistMuestraDesaparecido(Guid muestraId, Guid desaparecidoId);
}