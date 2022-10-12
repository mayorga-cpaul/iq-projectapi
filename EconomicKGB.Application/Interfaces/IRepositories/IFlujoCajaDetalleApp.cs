using SmartSolution.Application.Dtos.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IFlujoCajaDetalleApp: IRepositoryApplication<FlujoDeCajaDetalleDto>
    {
        Task<IEnumerable<FlujoDeCajaDetalleDto>> GetByFlujoId(int flujoId);
        Task<IEnumerable<EconomicDto>> GetEconomics(int flujoDetalle);
    }
}
