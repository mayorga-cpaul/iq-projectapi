﻿using SmartSolution.Domain.Entities.EntitiesBase;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Domain.EconomicContext
{
    public partial class EconomicKGBContext : DbContext
    {
        public EconomicKGBContext()
        {
        }

        public EconomicKGBContext(DbContextOptions<EconomicKGBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<InvesmentArea> AreaInversions { get; set; } = null!;
        public virtual DbSet<Conversion> Conversions { get; set; } = null!;
        public virtual DbSet<ProjectCost> CostProjects { get; set; } = null!;
        public virtual DbSet<Economic> EconomicClasses { get; set; } = null!;
        public virtual DbSet<InvestmentEntity> EntidadInvs { get; set; } = null!;
        public virtual DbSet<ProjectExpense> GastoProjects { get; set; } = null!;
        public virtual DbSet<ProjectEntry> IngresoProyectos { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Solution> Solutions { get; set; } = null!;
        public virtual DbSet<User> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<InvesmentArea>(entity =>
            {
                entity.ToTable(nameof(InvesmentArea));


                entity.HasIndex(e => e.ProjectId, "IX_InvesmentArea_ProjectId");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.IsInTheFirstYear);
                entity.Property(e => e.Start);
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.IsDepreciable);
                entity.Property(e => e.LifeSpan).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.IsDiferida)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
                entity.Property(e => e.Metodo);
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.InvestmentArea)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InvesmentArea");
            });

            modelBuilder.Entity<Conversion>(entity =>
            {
                entity.ToTable(nameof(Conversion));

                entity.HasIndex(e => e.UserId, "IX_Conversion_UserId");

                entity.Property(e => e.TasaActual).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TasaOriginal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoOriginal);
                entity.Property(e => e.TipoActual);
                entity.Property(e => e.FrecCapActual);
                entity.Property(e => e.FrecCapOriginal);
                entity.Property(e => e.CapitalizacionOriginal);
                entity.Property(e => e.CapitalizacionActual);
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Conversions)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ProjectCost>(entity =>
            {
                entity.ToTable(nameof(ProjectCost));


                entity.HasIndex(e => e.ProjectId, "IX_ProjectCost_ProjectId");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Growth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TypeGrowth).HasMaxLength(100);

                entity.Property(e => e.Start);

                entity.Property(e => e.End);

                entity.Property(e => e.CostType);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectCosts)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProjectCost");
            });

            modelBuilder.Entity<Economic>(entity =>
            {
                entity.ToTable(nameof(Economic));

                entity.HasIndex(e => e.SolutionId, "IX_Economic_SolutionId");

                entity.Property(e => e.PresentValue).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.FutureValue).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TasaInteres).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.NumPeriodos).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Discriminator);
                
                entity.Property(e => e.PagoAnual);
                
                entity.Property(e => e.TipoAnualidad);
                
                entity.Property(e => e.PeriodoGracia);
                
                entity.Property(e => e.Periodo);
                
                entity.Property(e => e.TipoInteres);
                
                entity.Property(e => e.FrecuenciaTasa);
                
                entity.Property(e => e.Crecimiento);
                
                entity.Property(e => e.FuturoGradiente);
                
                entity.Property(e => e.TipoDeCrecimiento);
                
                entity.HasOne(d => d.Solution)
                    .WithMany(p => p.Economics)
                    .HasForeignKey(d => d.SolutionId);
            });

            modelBuilder.Entity<InvestmentEntity>(entity =>
            {
                entity.ToTable(nameof(InvestmentEntity));


                entity.HasIndex(e => e.ProjectId, "IX_InvesmentEntity_ProjectId");

                entity.Property(e => e.FeeLevel)
                    .IsRequired()
                    .HasColumnName("ANivelada")
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Contribution).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Dni)
                    .HasMaxLength(100)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.IsPorcentage);
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.ProfileImage).HasColumnType("image");

                entity.Property(e => e.Tmar)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("TMAR");

                entity.Property(e => e.MoneyLoan);

                entity.Property(e => e.LoanTerm);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.InvestmentEntities)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EntitiesToProject");
            });

            modelBuilder.Entity<ProjectExpense>(entity =>
            {
                entity.ToTable(nameof(ProjectExpense));

                entity.HasIndex(e => e.ProjectId, "IX_ProjectExpense_ProjectId");

                entity.Property(e => e.Growth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Expense).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TypeGrowth).HasMaxLength(100);
                
                entity.Property(e => e.Start);
                
                entity.Property(e => e.End);
                
                entity.Property(e => e.TypeExpense);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectExpenses)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProjectExpense");
            });

            modelBuilder.Entity<ProjectEntry>(entity =>
            {
                entity.ToTable(nameof(ProjectEntry));

                entity.HasIndex(e => e.ProjectId, "IX_ProjecEntry_ProjectId");

                entity.Property(e => e.Growth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Entry).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TypeGrowth).HasMaxLength(100);
                entity.Property(e => e.Start);
                entity.Property(e => e.End);
                entity.Property(e => e.EntryType);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectEntries)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProjectEntry");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable(nameof(Project));

                entity.HasIndex(e => e.SolutionId, "IX_Project_SolutionId");

                entity.Property(e => e.Decription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Period).HasMaxLength(100);

                entity.Property(e => e.RecoveryCt);

                entity.Property(e => e.CreationDate);
                entity.Property(e => e.Duration);
                entity.Property(e => e.TMAR).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WithFinancement);

                entity.HasOne(d => d.Solution)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.SolutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Solution");
            });

            modelBuilder.Entity<Solution>(entity =>
            {
                entity.ToTable(nameof(Solution));

                entity.HasIndex(e => e.UserId, "IX_Solutions_UserId");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SolutionName).HasMaxLength(200);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Solutions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkUserSolutions");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(nameof(User));

                entity.Property(e => e.Dni)
                    .HasMaxLength(100)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(800);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Creation);

                entity.Property(e => e.ProfileImage).HasColumnType("image");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataApi") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataApi").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataApi").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}