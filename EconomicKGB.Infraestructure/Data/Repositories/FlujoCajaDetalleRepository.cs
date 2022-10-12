using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class FlujoCajaDetalleRepository : BaseRepository<FlujoDeCajaDetalle>, IFlujoCajaDetalleRepository
    {
        private readonly EconomicKGBContext repository;
        public FlujoCajaDetalleRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<FlujoDeCajaDetalle>> GetByFlujoId(int flujoId)
        {
            try
            {
                return await Task.FromResult(repository.FlujoDeCajaDetalles.Where(e => e.IdFlujoDeCaja == flujoId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Economic>> GetEconomics(int flujo)
        {
            try
            {
                //TODO: Probar si funciona el siguiente metodo
                return await Task.FromResult
                       (from economic in repository.EconomicClasses
                       join detalle in repository.FlujoDeCajaDetalles on economic.Id equals detalle.IdEconomic
                       where detalle.IdFlujoDeCaja == flujo
                       select economic);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
