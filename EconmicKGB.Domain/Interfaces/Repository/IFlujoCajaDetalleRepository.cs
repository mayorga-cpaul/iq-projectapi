using SmartSolution.Domain.Entities.EntitiesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IFlujoCajaDetalleRepository : IRepository<FlujoDeCajaDetalle>
    {
        Task<IEnumerable<FlujoDeCajaDetalle>> GetByFlujoId(int flujoId);
        Task<IEnumerable<Economic>> GetEconomics(int flujoDetalle);
    }
}
