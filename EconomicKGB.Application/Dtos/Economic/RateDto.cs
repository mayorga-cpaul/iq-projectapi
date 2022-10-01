using SmartSolution.Domain.Enums.Conversiones;
using SmartSolution.Domain.Enums.Types;
using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Dtos.Economic
{
    public class RateDto
    {
        public TipoInteres TipoInteres { get; set; }
        public FrecuenciaTasa FrecuenciaTasa { get; set; }
        //public int Capitalizacion { get; set; }
        //se puede ocultar esta capitalizacion
        //public int Capitalizacion => (int)FrecuenciaTasa;
        public int Capitalizacion => GetCapitalizacion();
        private int GetCapitalizacion()
        {
            if (TipoInteres.Equals(TipoInteres.CompuestoConTasaEfectiva) || TipoInteres.Equals(TipoInteres.Simple))
            {
                return 1;
            }
            string nombre = FrecuenciaTasa.ToString();
            return (int)Enum.Parse(typeof(FrecTasaNom), nombre);
        }
    }
}
