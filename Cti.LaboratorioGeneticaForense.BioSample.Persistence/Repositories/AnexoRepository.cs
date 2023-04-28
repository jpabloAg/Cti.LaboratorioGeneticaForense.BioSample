using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories
{
    public class AnexoRepository : IAnexoRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public AnexoRepository(ApplicationDbContext dbcontext) =>
            _dbcontext = dbcontext;

        public void Add(Anexo anexo) =>
            _dbcontext.Set<Anexo>().Add(anexo);

        public async Task<Anexo> GetById(Guid AnexoId) =>
            await _dbcontext.Set<Anexo>().FirstOrDefaultAsync(x => x.Id == AnexoId);
    }
}
