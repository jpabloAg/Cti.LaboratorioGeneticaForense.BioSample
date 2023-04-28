namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}