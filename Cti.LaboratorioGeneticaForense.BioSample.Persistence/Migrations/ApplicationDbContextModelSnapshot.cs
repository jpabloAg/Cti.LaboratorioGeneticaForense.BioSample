﻿// <auto-generated />
using System;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Anexo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("MuestraId")
                        .HasColumnType("uuid");

                    b.Property<string>("OT")
                        .HasColumnType("text");

                    b.Property<string>("Observaciones")
                        .HasColumnType("text");

                    b.Property<string>("Perito")
                        .HasColumnType("text");

                    b.Property<string>("UriDocumentacion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MuestraId")
                        .IsUnique();

                    b.ToTable("Anexo", (string)null);
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Desaparecido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Genero")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("text");

                    b.Property<string>("Sirdec")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("integer");

                    b.Property<string>("documentoIdentidad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Desaparecido", (string)null);
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ConsentimientoPoblacional")
                        .HasColumnType("boolean");

                    b.Property<int>("EstadoMuestra")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("FechaLlegadaLaboratorio")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaTomaMuestra")
                        .HasColumnType("date");

                    b.Property<Guid>("MuestradanteId")
                        .HasColumnType("uuid");

                    b.Property<string>("RadicadoInterno")
                        .HasColumnType("text");

                    b.Property<int>("TipoMuestra")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MuestradanteId")
                        .IsUnique();

                    b.ToTable("Muestra", (string)null);
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestradante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("DocumentoIdentidad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Parentesco")
                        .HasColumnType("integer");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Muestradante", (string)null);
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.MuestraDesaparecido", b =>
                {
                    b.Property<Guid>("MuestraId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DesaparecidoId")
                        .HasColumnType("uuid");

                    b.HasKey("MuestraId", "DesaparecidoId");

                    b.HasIndex("DesaparecidoId");

                    b.ToTable("MuestraDesaparecido", (string)null);
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Anexo", b =>
                {
                    b.HasOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestra", null)
                        .WithOne("Anexo")
                        .HasForeignKey("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Anexo", "MuestraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Desaparecido", b =>
                {
                    b.OwnsOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects.Region", "LugarNacimiento", b1 =>
                        {
                            b1.Property<Guid>("DesaparecidoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Departamento")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("LugarNacimientoDepartamento");

                            b1.Property<string>("Municipio")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("LugarNacimientoMunicipio");

                            b1.HasKey("DesaparecidoId");

                            b1.ToTable("Desaparecido");

                            b1.WithOwner()
                                .HasForeignKey("DesaparecidoId");
                        });

                    b.OwnsOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects.Region", "LugarTomaCuerpo", b1 =>
                        {
                            b1.Property<Guid>("DesaparecidoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Departamento")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("LugarTomaCuerpoDepartamento");

                            b1.Property<string>("Municipio")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("LugarTomaCuerpoMunicipio");

                            b1.HasKey("DesaparecidoId");

                            b1.ToTable("Desaparecido");

                            b1.WithOwner()
                                .HasForeignKey("DesaparecidoId");
                        });

                    b.Navigation("LugarNacimiento")
                        .IsRequired();

                    b.Navigation("LugarTomaCuerpo")
                        .IsRequired();
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestra", b =>
                {
                    b.HasOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestradante", null)
                        .WithOne("muestra")
                        .HasForeignKey("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestra", "MuestradanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects.Region", "LugarTomaMuestra", b1 =>
                        {
                            b1.Property<Guid>("MuestraId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Departamento")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Departamento");

                            b1.Property<string>("Municipio")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Municipio");

                            b1.HasKey("MuestraId");

                            b1.ToTable("Muestra");

                            b1.WithOwner()
                                .HasForeignKey("MuestraId");
                        });

                    b.Navigation("LugarTomaMuestra")
                        .IsRequired();
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestradante", b =>
                {
                    b.OwnsOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects.Region", "LugarNacimiento", b1 =>
                        {
                            b1.Property<Guid>("MuestradanteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Departamento")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Departamento");

                            b1.Property<string>("Municipio")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Municipio");

                            b1.HasKey("MuestradanteId");

                            b1.ToTable("Muestradante");

                            b1.WithOwner()
                                .HasForeignKey("MuestradanteId");
                        });

                    b.Navigation("LugarNacimiento")
                        .IsRequired();
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.MuestraDesaparecido", b =>
                {
                    b.HasOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Desaparecido", "Desaparecido")
                        .WithMany("MuestrasDesaparecidos")
                        .HasForeignKey("DesaparecidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestra", "Muestra")
                        .WithMany("MuestrasDesaparecidos")
                        .HasForeignKey("MuestraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desaparecido");

                    b.Navigation("Muestra");
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Desaparecido", b =>
                {
                    b.Navigation("MuestrasDesaparecidos");
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestra", b =>
                {
                    b.Navigation("Anexo")
                        .IsRequired();

                    b.Navigation("MuestrasDesaparecidos");
                });

            modelBuilder.Entity("Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities.Muestradante", b =>
                {
                    b.Navigation("muestra")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
