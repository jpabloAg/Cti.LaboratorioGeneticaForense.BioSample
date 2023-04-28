using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muestradante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    PrimerApellido = table.Column<string>(type: "text", nullable: false),
                    SegundoApellido = table.Column<string>(type: "text", nullable: true),
                    Parentesco = table.Column<int>(type: "integer", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Municipio = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    TipoDocumento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muestradante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muestra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RadicadoInterno = table.Column<string>(type: "text", nullable: true),
                    TipoMuestra = table.Column<int>(type: "integer", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Municipio = table.Column<string>(type: "text", nullable: false),
                    EstadoMuestra = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Muestra_MuestradanteId",
                table: "Muestra",
                column: "MuestradanteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Muestra");

            migrationBuilder.DropTable(
                name: "Muestradante");
        }
    }
}
