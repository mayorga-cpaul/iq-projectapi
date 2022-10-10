using System;
using System.Collections.Generic;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class FlujoDeCaja
    {
        public int Id { get; set; }
        public decimal PresentValue { get; set; }
        public decimal FutureValue { get; set; }
        public decimal TasaDeInteres { get; set; }
        public decimal Duracion { get; set; }
        public int Periodo { get; set; }
        public int SolutionId { get; set; }

        public virtual Solution Solution { get; set; } = null!;
    }
}
