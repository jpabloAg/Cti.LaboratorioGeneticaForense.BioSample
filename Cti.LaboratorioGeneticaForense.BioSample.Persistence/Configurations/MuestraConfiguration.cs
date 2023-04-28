using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Configurations;

internal sealed class MuestraConfiguration : IEntityTypeConfiguration<Muestra>
{
    public void Configure(EntityTypeBuilder<Muestra> builder)
    {
        builder.ToTable(TableNames.Muestra);

        builder.HasKey(muestra => muestra.Id);

        builder.OwnsOne(muestra => muestra.LugarTomaMuestra,
            navigationBuilder =>
            {
                navigationBuilder.Property(LugarTomaMuestra => LugarTomaMuestra.Municipio)
                                 .HasColumnName("Municipio");

                navigationBuilder.Property(LugarTomaMuestra => LugarTomaMuestra.Departamento)
                                 .HasColumnName("Departamento");
            });
    }
}


