using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Configurations;
internal sealed class MuestradanteConfiguration : IEntityTypeConfiguration<Muestradante>
{
    public void Configure(EntityTypeBuilder<Muestradante> builder)
    {
        builder.ToTable(TableNames.Muestradante);

        builder.HasKey(muestradante => muestradante.Id);

        builder.OwnsOne(muestradante => muestradante.LugarNacimiento,
            navigationBuilder =>
            {
                navigationBuilder.Property(lugarNacimiento => lugarNacimiento.Municipio)
                                 .HasColumnName("Municipio");

                navigationBuilder.Property(lugarNacimiento => lugarNacimiento.Departamento)
                                 .HasColumnName("Departamento");
            });
    }
}