using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories
{
    public sealed class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _dbcontext;

        public UsuarioRepository(ApplicationDbContext dbcontext) =>
        _dbcontext = dbcontext;

        public void Add(Usuario usuario) =>
            _dbcontext.Set<Usuario>().Add(usuario);

        public async Task<Usuario?> GetUsurio(string EmailAddress, string Password)
        {
            return await _dbcontext.Set<Usuario>().FirstOrDefaultAsync(u => u.EmailAddress.ToLower() == EmailAddress.ToLower() && u.Password == Password);
        }
    }
}
