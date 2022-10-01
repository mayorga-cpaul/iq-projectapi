using SmartSolution.Domain.Enums.Types;
using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Dtos.Economic
{
    public class AnnuityDto 
    {
        public decimal PagoAnual { get; set; }
        public TipoAnualidad TipoAnualidad { get; set; }
        public int PeriodoGracia { get; set; }
        public Periodo Periodo { get; set; }
        public decimal Crecimiento { get; set; }
        public TipoCrecimiento TipoDeCrecimiento { get; set; }
        public decimal FuturoGradiente { get; set; }
    }
}
