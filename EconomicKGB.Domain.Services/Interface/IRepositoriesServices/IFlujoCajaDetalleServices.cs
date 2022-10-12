using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IFlujoCajaDetalleServices : IRepositoryServices<FlujoDeCajaDetalle>
    {
        Task<IEnumerable<FlujoDeCajaDetalle>> GetByFlujoId(int flujoId);
        Task<IEnumerable<Economic>> GetEconomics(int flujoDetalle);
    }
}
