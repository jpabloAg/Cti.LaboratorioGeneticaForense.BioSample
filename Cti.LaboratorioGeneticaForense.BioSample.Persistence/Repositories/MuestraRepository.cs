using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;

public sealed class MuestraRepository : IMuestraRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public MuestraRepository(ApplicationDbContext dbcontext) =>
        _dbcontext = dbcontext;

    public void Add(Muestra muestra) =>
        _dbcontext.Set<Muestra>().Add(muestra);

    public async Task<bool> ExistsMuestra(Guid muestradanteId)
    {
        return await _dbcontext.Set<Muestra>().AnyAsync(m => m.MuestradanteId == muestradanteId);
    }
}

