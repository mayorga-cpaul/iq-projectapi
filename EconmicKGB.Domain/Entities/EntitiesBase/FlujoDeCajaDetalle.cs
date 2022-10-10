using System;
using System.Collections.Generic;

namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class FlujoDeCajaDetalle
    {
        public int IdFlujoDeCaja { get; set; }
        public int IdEconomic { get; set; }

        public virtual Economic IdEconomicNavigation { get; set; } = null!;
        public virtual FlujoDeCaja IdFlujoDeCajaNavigation { get; set; } = null!;
    }
}
