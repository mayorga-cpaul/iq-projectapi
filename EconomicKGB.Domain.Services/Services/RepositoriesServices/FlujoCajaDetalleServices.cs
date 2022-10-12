using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Services.Interface.IRepositoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Services.Services.RepositoriesServices
{
    public class FlujoCajaDetalleServices : BaseServices<FlujoDeCajaDetalle>, IFlujoCajaDetalleServices
    {
        private IFlujoCajaDetalleRepository flujoCajaDetalleRepository;

        public FlujoCajaDetalleServices(IFlujoCajaDetalleRepository flujoCajaDetalleRepository) : base(flujoCajaDetalleRepository)
        {
            this.flujoCajaDetalleRepository = flujoCajaDetalleRepository;
        }

        public async Task<IEnumerable<FlujoDeCajaDetalle>> GetByFlujoId(int flujoId)
        {
            try
            {
                return await flujoCajaDetalleRepository.GetByFlujoId(flujoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Economic>> GetEconomics(int flujoId)
        {
            try
            {
                return await flujoCajaDetalleRepository.GetEconomics(flujoId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
