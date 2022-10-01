using System;
using System.Collections.Generic;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class ProjectCost
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public decimal Cost { get; set; }
        public decimal? Growth { get; set; }
        public string? TypeGrowth { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string? CostType { get; set; }

        public virtual Project Project { get; set; } = null!;
    }
}
