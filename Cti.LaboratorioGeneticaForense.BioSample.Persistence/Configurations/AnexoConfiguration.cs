using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Configurations
{
    internal class AnexoConfiguration : IEntityTypeConfiguration<Anexo>
    {
        public void Configure(EntityTypeBuilder<Anexo> builder)
        {
            builder.ToTable(TableNames.Anexo);

            builder.HasKey(anexo => anexo.Id);
        }
    }
}
