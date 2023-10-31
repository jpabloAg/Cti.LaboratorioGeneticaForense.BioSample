using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Configurations
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(TableNames.Usuario);

            builder.HasKey(usuario => usuario.Id);
        }
    }
}
