using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class Project
    {
        public Project()
        {
            InvestmentArea = new HashSet<InvesmentArea>();
            ProjectCosts = new HashSet<ProjectCost>();
            InvestmentEntities = new HashSet<InvestmentEntity>();
            ProjectExpenses = new HashSet<ProjectExpense>();
            ProjectEntries = new HashSet<ProjectEntry>();
        }

        public int Id { get; set; }
        public int SolutionId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Decription { get; set; }
        public string Period { get; set; } = String.Empty;
        public int Duration { get; set; }
        public bool WithFinancement { get; set; }
        public decimal RecoveryCt { get; set; }
        public decimal TMAR { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal TMARMixta { get; set; }
        public decimal Contribution { get; set; }
        public virtual Solution Solution { get; set; } = null!;
        public virtual ICollection<InvesmentArea> InvestmentArea { get; set; }
        public virtual ICollection<ProjectCost> ProjectCosts { get; set; }
        public virtual ICollection<InvestmentEntity> InvestmentEntities { get; set; }
        public virtual ICollection<ProjectExpense> ProjectExpenses { get; set; }
        public virtual ICollection<ProjectEntry> ProjectEntries { get; set; } 
    }
}
