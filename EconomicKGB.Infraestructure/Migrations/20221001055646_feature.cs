using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSolution.Infraestructure.Migrations
{
    public partial class feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "image", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(800)", maxLength: 800, nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TasaOriginal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoOriginal = table.Column<int>(type: "int", nullable: false),
                    TipoActual = table.Column<int>(type: "int", nullable: false),
                    FrecCapOriginal = table.Column<int>(type: "int", nullable: false),
                    FrecCapActual = table.Column<int>(type: "int", nullable: false),
                    CapitalizacionOriginal = table.Column<int>(type: "int", nullable: false),
                    CapitalizacionActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversion_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SolutionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.Id);
                    table.ForeignKey(
                        name: "fkUserSolutions",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Economic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    PresentValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    FutureValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TasaInteres = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    NumPeriodos = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagoAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoAnualidad = table.Column<int>(type: "int", nullable: true),
                    PeriodoGracia = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: true),
                    TipoInteres = table.Column<int>(type: "int", nullable: true),
                    FrecuenciaTasa = table.Column<int>(type: "int", nullable: true),
                    Crecimiento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FuturoGradiente = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoDeCrecimiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Economic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Economic_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Decription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Period = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    WithFinancement = table.Column<bool>(type: "bit", nullable: false),
                    RecoveryCt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TMAR = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Solution",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvesmentArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsInTheFirstYear = table.Column<bool>(type: "bit", nullable: false),
                    Start = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IsDepreciable = table.Column<bool>(type: "bit", nullable: false),
                    LifeSpan = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IsDiferida = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    Metodo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvesmentArea", x => x.Id);
                    table.ForeignKey(
                        name: "fk_InvesmentArea",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvestmentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsPorcentage = table.Column<bool>(type: "bit", nullable: false),
                    Contribution = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TMAR = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ProfileImage = table.Column<byte[]>(type: "image", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoneyLoan = table.Column<bool>(type: "bit", nullable: false),
                    ANivelada = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    LoanTerm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "fk_EntitiesToProject",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Growth = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TypeGrowth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Start = table.Column<int>(type: "int", nullable: false),
                    End = table.Column<int>(type: "int", nullable: false),
                    CostType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCost", x => x.Id);
                    table.ForeignKey(
                        name: "fk_ProjectCost",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Entry = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Growth = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TypeGrowth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Start = table.Column<int>(type: "int", nullable: false),
                    End = table.Column<int>(type: "int", nullable: false),
                    EntryType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntry", x => x.Id);
                    table.ForeignKey(
                        name: "fk_ProjectEntry",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Expense = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Growth = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TypeGrowth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Start = table.Column<int>(type: "int", nullable: false),
                    End = table.Column<int>(type: "int", nullable: false),
                    TypeExpense = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectExpense", x => x.Id);
                    table.ForeignKey(
                        name: "fk_ProjectExpense",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_UserId",
                table: "Conversion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Economic_SolutionId",
                table: "Economic",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvesmentArea_ProjectId",
                table: "InvesmentArea",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InvesmentEntity_ProjectId",
                table: "InvestmentEntity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_SolutionId",
                table: "Project",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCost_ProjectId",
                table: "ProjectCost",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjecEntry_ProjectId",
                table: "ProjectEntry",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpense_ProjectId",
                table: "ProjectExpense",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_UserId",
                table: "Solution",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversion");

            migrationBuilder.DropTable(
                name: "Economic");

            migrationBuilder.DropTable(
                name: "InvesmentArea");

            migrationBuilder.DropTable(
                name: "InvestmentEntity");

            migrationBuilder.DropTable(
                name: "ProjectCost");

            migrationBuilder.DropTable(
                name: "ProjectEntry");

            migrationBuilder.DropTable(
                name: "ProjectExpense");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Solution");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
