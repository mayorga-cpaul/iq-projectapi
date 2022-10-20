using SmartSolution.Domain.Enums.Types;
using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Dtos.Economic
{
    //TODO: El rate Dto no tiene las propiedades que estan en economic
    public class AnnuityDto 
    {
        public int Id { get; set; }
        public int IdSolution { get; set; }
        public decimal PresentValue { get; set; }
        public decimal FutureValue { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal NumPeriodos { get; set; }
        public decimal PagoAnual { get; set; }
        public TipoAnualidad TipoAnualidad { get; set; }
        public decimal PeriodoGracia { get; set; }
        public Periodo Periodo { get; set; }
        public decimal Crecimiento { get; set; }
        public TipoCrecimiento TipoDeCrecimiento { get; set; }
        public decimal FuturoGradiente { get; set; }
    }
}
