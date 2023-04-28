using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;

public sealed class MuestraDesaparecidoRepository : IMuestraDesaparecidoRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public MuestraDesaparecidoRepository(ApplicationDbContext dbcontext) =>
        _dbcontext = dbcontext;

    public async Task<bool> ExistMuestraDesaparecido(Guid muestraId, Guid desaparecidoId)
    {
        return await _dbcontext.Set<MuestraDesaparecido>()
                                    .AnyAsync(x => 
                                        x.MuestraId.Equals(muestraId) && 
                                        x.DesaparecidoId.Equals(desaparecidoId));
    }

    public void VincularMuestraDesaparecido(MuestraDesaparecido muestraDesaparecido) =>
        _dbcontext.Set<MuestraDesaparecido>().Add(muestraDesaparecido);
}
