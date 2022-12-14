using System;
using System.Collections.Generic;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class Solution
    {
        public Solution()
        {
            Projects = new HashSet<Project>();
            Economics = new HashSet<Economic>();
            FlujoDeCajas = new HashSet<FlujoDeCaja>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string SolutionName { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Economic> Economics { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<FlujoDeCaja> FlujoDeCajas { get; set; }
    }
}
