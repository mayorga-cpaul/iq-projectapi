using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSolution.Infraestructure.Migrations
{
    public partial class PropAndMoreProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "InvestmentEntity");

            migrationBuilder.AddColumn<decimal>(
                name: "Contribution",
                table: "Project",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TipoDeAmortización",
                table: "InvestmentEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contribution",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TipoDeAmortización",
                table: "InvestmentEntity");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "InvestmentEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
