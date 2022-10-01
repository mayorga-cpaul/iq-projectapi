namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public class EconomicDto
    {
        public int IdUser { get; set; }
        public decimal ValorPresente { get; set; }
        public decimal ValorFuturo { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal NumPeriodos { get; set; }
    }
}