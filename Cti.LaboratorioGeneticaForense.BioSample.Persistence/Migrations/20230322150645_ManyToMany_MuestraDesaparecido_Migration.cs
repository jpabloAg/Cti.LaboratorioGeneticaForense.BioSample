using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Migrations
{
    public partial class ManyToMany_MuestraDesaparecido_Migration : Migration
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
                    TipoDocumento = table.Column<int>(type: "integer", nullable: false),
                    PrimerApellido = table.Column<string>(type: "text", nullable: false),
                    SegundoApellido = table.Column<string>(type: "text", nullable: true),
                    Genero = table.Column<int>(type: "integer", nullable: false),
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
                name: "IX_MuestraDesaparecido_DesaparecidoId",
                table: "MuestraDesaparecido",
                column: "DesaparecidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuestraDesaparecido");

            migrationBuilder.DropTable(
                name: "Desaparecido");
        }
    }
}
