using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Configurations;
internal class DesaparecidoConfiguration : IEntityTypeConfiguration<Desaparecido>
{
    public void Configure(EntityTypeBuilder<Desaparecido> builder)
    {
        builder.ToTable(TableNames.Desaparecido);

        builder.HasKey(desaparecido => desaparecido.Id);

        builder.OwnsOne(desaparecido => desaparecido.LugarNacimiento,
            navigationBuilder =>
            {
                navigationBuilder.Property(lugarNacimiento => lugarNacimiento.Municipio)
                                 .HasColumnName("LugarNacimientoMunicipio");

                navigationBuilder.Property(lugarNacimiento => lugarNacimiento.Departamento)
                                 .HasColumnName("LugarNacimientoDepartamento");
            });

        builder.OwnsOne(desaparecido => desaparecido.LugarTomaCuerpo,
            navigationBuilder =>
            {
                navigationBuilder.Property(LugarTomaCuerpo => LugarTomaCuerpo.Municipio)
                                 .HasColumnName("LugarTomaCuerpoMunicipio");

                navigationBuilder.Property(LugarTomaCuerpo => LugarTomaCuerpo.Departamento)
                                 .HasColumnName("LugarTomaCuerpoDepartamento");
            });
    }
}

