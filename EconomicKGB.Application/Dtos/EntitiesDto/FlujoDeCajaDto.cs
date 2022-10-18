using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public class FlujoDeCajaDto
    {
        public int Id { get; set; }
        public decimal PresentValue { get; set; }
        public decimal FutureValue { get; set; }
        public decimal TasaDeInteres { get; set; }
        public decimal Duracion { get; set; }
        public int Periodo { get; set; }
        public int SolutionId { get; set; }
    }
}
