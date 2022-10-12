namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public class EconomicDto
    {
        //TODO: atributos de economicDto antes de cambio
        //public int IdUser { get; set; }
        //public decimal ValorPresente { get; set; }
        //public decimal ValorFuturo { get; set; }
        //public decimal TasaInteres { get; set; }
        //public decimal NumPeriodos { get; set; }

        //TODO: atributos de economicDto despues de cambio
        public int Id { get; set; }
        public int SolutionId { get; set; }
        public decimal PresentValue { get; set; }
        public decimal FutureValue { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal NumPeriodos { get; set; }
        public string Discriminator { get; set; } = null!;
        public decimal? PagoAnual { get; set; }
        public int? TipoAnualidad { get; set; }
        public int PeriodoGracia { get; set; }
        public int? Periodo { get; set; }
        public int? TipoInteres { get; set; }
        public int? FrecuenciaTasa { get; set; }
        public decimal? Crecimiento { get; set; }
        public decimal? FuturoGradiente { get; set; }
        public int? TipoDeCrecimiento { get; set; }
    }
}