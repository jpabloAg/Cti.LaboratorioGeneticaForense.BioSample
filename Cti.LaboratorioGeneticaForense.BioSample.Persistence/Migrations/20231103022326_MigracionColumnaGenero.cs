using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cti.LaboratorioGeneticaForense.BioSample.Persistence.Migrations
{
    public partial class MigracionColumnaGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Muestradante",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Muestradante");
        }
    }
}
