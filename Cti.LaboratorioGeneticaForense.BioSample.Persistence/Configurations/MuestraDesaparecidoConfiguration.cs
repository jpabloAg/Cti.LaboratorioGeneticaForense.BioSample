using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Configurations;

internal class MuestraDesaparecidoConfiguration : IEntityTypeConfiguration<MuestraDesaparecido>
{
    public void Configure(EntityTypeBuilder<MuestraDesaparecido> builder)
    {
        builder.ToTable(TableNames.MuestraDesaparecido);

        builder.HasKey(muestraDesaparecido => 
            new { muestraDesaparecido.MuestraId, muestraDesaparecido.DesaparecidoId });
    }
}
