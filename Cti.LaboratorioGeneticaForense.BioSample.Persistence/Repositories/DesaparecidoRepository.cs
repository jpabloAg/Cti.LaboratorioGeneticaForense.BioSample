using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;

public sealed class DesaparecidoRepository : IDesaparecidoRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public DesaparecidoRepository(ApplicationDbContext dbcontext) =>
        _dbcontext = dbcontext;

    public void Add(Desaparecido desaparecido) =>
        _dbcontext.Set<Desaparecido>().Add(desaparecido);

    public IEnumerable<Desaparecido> GetMuestras(Guid Id)
    {
        return _dbcontext.Set<Desaparecido>()
            .Where(x => x.Id.Equals(Id))
                .Include(x => x.MuestrasDesaparecidos)
                    .ThenInclude(muestraDesaparecido => muestraDesaparecido.Muestra);
    }
}
