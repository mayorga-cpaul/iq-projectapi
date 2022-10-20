using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSolution.Infraestructure.Migrations
{
    public partial class EconomicKGB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdSolution",
                table: "FlujoDeCaja",
                newName: "SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_FlujoDeCaja_IdSolution",
                table: "FlujoDeCaja",
                newName: "IX_FlujoDeCaja_SolutionId");

            migrationBuilder.AlterColumn<int>(
                name: "Periodo",
                table: "FlujoDeCaja",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SolutionId",
                table: "FlujoDeCaja",
                newName: "IdSolution");

            migrationBuilder.RenameIndex(
                name: "IX_FlujoDeCaja_SolutionId",
                table: "FlujoDeCaja",
                newName: "IX_FlujoDeCaja_IdSolution");

            migrationBuilder.AlterColumn<decimal>(
                name: "Periodo",
                table: "FlujoDeCaja",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
