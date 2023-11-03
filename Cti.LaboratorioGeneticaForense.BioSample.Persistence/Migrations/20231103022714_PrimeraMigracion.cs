using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desaparecido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    documentoIdentidad = table.Column<string>(type: "text", nullable: false),
                    TipoDocumento = table.Column<string>(type: "text", nullable: false),
                    PrimerApellido = table.Column<string>(type: "text", nullable: false),
                    SegundoApellido = table.Column<string>(type: "text", nullable: true),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    Sirdec = table.Column<string>(type: "text", nullable: false),
                    LugarNacimientoDepartamento = table.Column<string>(type: "text", nullable: false),
                    LugarNacimientoMunicipio = table.Column<string>(type: "text", nullable: false),
                    LugarTomaCuerpoDepartamento = table.Column<string>(type: "text", nullable: false),
                    LugarTomaCuerpoMunicipio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desaparecido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muestradante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    PrimerApellido = table.Column<string>(type: "text", nullable: false),
                    SegundoApellido = table.Column<string>(type: "text", nullable: true),
                    Parentesco = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Municipio = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    TipoDocumento = table.Column<string>(type: "text", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muestradante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    GivenName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muestra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RadicadoInterno = table.Column<string>(type: "text", nullable: true),
                    TipoMuestra = table.Column<string>(type: "text", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Municipio = table.Column<string>(type: "text", nullable: false),
                    EstadoMuestra = table.Column<string>(type: "text", nullable: false),
                    FechaTomaMuestra = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaLlegadaLaboratorio = table.Column<DateOnly>(type: "date", nullable: false),
                    ConsentimientoPoblacional = table.Column<bool>(type: "boolean", nullable: false),
                    MuestradanteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muestra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Muestra_Muestradante_MuestradanteId",
                        column: x => x.MuestradanteId,
                        principalTable: "Muestradante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anexo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OT = table.Column<string>(type: "text", nullable: true),
                    Perito = table.Column<string>(type: "text", nullable: true),
                    Observaciones = table.Column<string>(type: "text", nullable: true),
                    UriDocumentacion = table.Column<string>(type: "text", nullable: true),
                    MuestraId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anexo_Muestra_MuestraId",
                        column: x => x.MuestraId,
                        principalTable: "Muestra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuestraDesaparecido",
                columns: table => new
                {
                    MuestraId = table.Column<Guid>(type: "uuid", nullable: false),
                    DesaparecidoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuestraDesaparecido", x => new { x.MuestraId, x.DesaparecidoId });
                    table.ForeignKey(
                        name: "FK_MuestraDesaparecido_Desaparecido_DesaparecidoId",
                        column: x => x.DesaparecidoId,
                        principalTable: "Desaparecido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuestraDesaparecido_Muestra_MuestraId",
                        column: x => x.MuestraId,
                        principalTable: "Muestra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_MuestraId",
                table: "Anexo",
                column: "MuestraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muestra_MuestradanteId",
                table: "Muestra",
                column: "MuestradanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MuestraDesaparecido_DesaparecidoId",
                table: "MuestraDesaparecido",
                column: "DesaparecidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anexo");

            migrationBuilder.DropTable(
                name: "MuestraDesaparecido");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Desaparecido");

            migrationBuilder.DropTable(
                name: "Muestra");

            migrationBuilder.DropTable(
                name: "Muestradante");
        }
    }
}
