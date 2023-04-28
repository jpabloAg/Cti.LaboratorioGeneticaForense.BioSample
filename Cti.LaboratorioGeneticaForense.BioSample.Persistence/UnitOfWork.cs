using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
