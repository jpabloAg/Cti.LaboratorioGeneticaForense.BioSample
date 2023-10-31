using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        Task<Usuario?> GetUsurio(string EmailAddress, string Password);
    }
}
