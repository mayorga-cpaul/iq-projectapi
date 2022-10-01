using System;
using System.Collections.Generic;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class Conversion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TasaOriginal { get; set; }
        public decimal TasaActual { get; set; }
        public int TipoOriginal { get; set; }
        public int TipoActual { get; set; }
        public int FrecCapOriginal { get; set; }
        public int FrecCapActual { get; set; }
        public int CapitalizacionOriginal { get; set; }
        public int CapitalizacionActual { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
