using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;

public sealed class MuestradanteRepository : IMuestradanteRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public MuestradanteRepository(ApplicationDbContext dbcontext) =>
        _dbcontext = dbcontext;

    public void Add(Muestradante muestradante) =>
        _dbcontext.Set<Muestradante>().Add(muestradante);

    public async Task<Muestradante?> GetByIdAsync(string documentoIdentidad)
    {
        return await _dbcontext.Set<Muestradante>().FirstOrDefaultAsync(m => m.DocumentoIdentidad == documentoIdentidad);
    }
}