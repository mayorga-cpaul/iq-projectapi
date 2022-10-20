using System;
using System.Collections.Generic;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public class Economic
    {
        public int Id { get; set; }
        public int SolutionId { get; set; }
        public decimal PresentValue { get; set; }
        public decimal FutureValue { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal NumPeriodos { get; set; }
        public string Discriminator { get; set; } = null!;
        public decimal? PagoAnual { get; set; }
        public int? TipoAnualidad { get; set; }
        public decimal PeriodoGracia { get; set; }
        public int? Periodo { get; set; }
        public int? TipoInteres { get; set; }
        public int? FrecuenciaTasa { get; set; }
        public decimal? Crecimiento { get; set; }
        public decimal? FuturoGradiente { get; set; }
        public int? TipoDeCrecimiento { get; set; }

        public virtual Solution Solution { get; set; } = null!;
    }
}