﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSolution.Domain.EconomicContext;

#nullable disable

namespace SmartSolution.Infraestructure.Migrations
{
    [DbContext(typeof(EconomicKGBContext))]
    [Migration("20221001055646_feature")]
    partial class feature
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Conversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CapitalizacionActual")
                        .HasColumnType("int");

                    b.Property<int>("CapitalizacionOriginal")
                        .HasColumnType("int");

                    b.Property<int>("FrecCapActual")
                        .HasColumnType("int");

                    b.Property<int>("FrecCapOriginal")
                        .HasColumnType("int");

                    b.Property<decimal>("TasaActual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TasaOriginal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoActual")
                        .HasColumnType("int");

                    b.Property<int>("TipoOriginal")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_Conversion_UserId");

                    b.ToTable("Conversion", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Economic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Crecimiento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FrecuenciaTasa")
                        .HasColumnType("int");

                    b.Property<decimal>("FutureValue")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal?>("FuturoGradiente")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NumPeriodos")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal?>("PagoAnual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Periodo")
                        .HasColumnType("int");

                    b.Property<int>("PeriodoGracia")
                        .HasColumnType("int");

                    b.Property<decimal>("PresentValue")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("SolutionId")
                        .HasColumnType("int");

                    b.Property<decimal>("TasaInteres")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int?>("TipoAnualidad")
                        .HasColumnType("int");

                    b.Property<int?>("TipoDeCrecimiento")
                        .HasColumnType("int");

                    b.Property<int?>("TipoInteres")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SolutionId" }, "IX_Economic_SolutionId");

                    b.ToTable("Economic", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.InvesmentArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,0)");

                    b.Property<bool>("IsDepreciable")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDiferida")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.Property<bool>("IsInTheFirstYear")
                        .HasColumnType("bit");

                    b.Property<decimal>("LifeSpan")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("Metodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectId" }, "IX_InvesmentArea_ProjectId");

                    b.ToTable("InvesmentArea", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.InvestmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Contribution")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("Dni")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DNI");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("FeeLevel")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("ANivelada")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.Property<bool>("IsPorcentage")
                        .HasColumnType("bit");

                    b.Property<int>("LoanTerm")
                        .HasColumnType("int");

                    b.Property<bool>("MoneyLoan")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("image");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Tmar")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("TMAR");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectId" }, "IX_InvesmentEntity_ProjectId");

                    b.ToTable("InvestmentEntity", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Decription")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("RecoveryCt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SolutionId")
                        .HasColumnType("int");

                    b.Property<decimal>("TMAR")
                        .HasColumnType("decimal(18,0)");

                    b.Property<bool>("WithFinancement")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SolutionId" }, "IX_Project_SolutionId");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.ProjectCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("CostType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<decimal?>("Growth")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.Property<string>("TypeGrowth")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectId" }, "IX_ProjectCost_ProjectId");

                    b.ToTable("ProjectCost", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.ProjectEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<decimal>("Entry")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("EntryType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Growth")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.Property<string>("TypeGrowth")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectId" }, "IX_ProjecEntry_ProjectId");

                    b.ToTable("ProjectEntry", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.ProjectExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<decimal>("Expense")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal?>("Growth")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.Property<string>("TypeExpense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeGrowth")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectId" }, "IX_ProjectExpense_ProjectId");

                    b.ToTable("ProjectExpense", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Solution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("SolutionName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_Solutions_UserId");

                    b.ToTable("Solution", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dni")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DNI");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Password")
                        .HasMaxLength(800)
                        .HasColumnType("varbinary(800)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("image");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Conversion", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.User", "User")
                        .WithMany("Conversions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Economic", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.Solution", "Solution")
                        .WithMany("Economics")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.InvesmentArea", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.Project", "Project")
                        .WithMany("InvestmentArea")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("fk_InvesmentArea");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.InvestmentEntity", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.Project", "Project")
                        .WithMany("InvestmentEntities")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("fk_EntitiesToProject");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Project", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.Solution", "Solution")
                        .WithMany("Projects")
                        .HasForeignKey("SolutionId")
                        .IsRequired()
                        .HasConstraintName("fk_Solution");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.ProjectCost", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.Project", "Project")
                        .WithMany("ProjectCosts")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("fk_ProjectCost");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.ProjectEntry", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.Project", "Project")
                        .WithMany("ProjectEntries")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("fk_ProjectEntry");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.ProjectExpense", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.Project", "Project")
                        .WithMany("ProjectExpenses")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("fk_ProjectExpense");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Solution", b =>
                {
                    b.HasOne("SmartSolution.Domain.Entities.EntitiesBase.User", "User")
                        .WithMany("Solutions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fkUserSolutions");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Project", b =>
                {
                    b.Navigation("InvestmentArea");

                    b.Navigation("InvestmentEntities");

                    b.Navigation("ProjectCosts");

                    b.Navigation("ProjectEntries");

                    b.Navigation("ProjectExpenses");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.Solution", b =>
                {
                    b.Navigation("Economics");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("SmartSolution.Domain.Entities.EntitiesBase.User", b =>
                {
                    b.Navigation("Conversions");

                    b.Navigation("Solutions");
                });
#pragma warning restore 612, 618
        }
    }
}
