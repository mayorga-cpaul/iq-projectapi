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
    public class FlujoCajaRepository : BaseRepository<FlujoDeCaja>, IFlujoDeCajaRepository
    {
        private readonly EconomicKGBContext repository;
        public FlujoCajaRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<FlujoDeCaja>> GetBySolutionID(int solutionID)
        {
            try
            {
                return await Task.FromResult(repository.FlujoDeCajas.Where(e => e.SolutionId == solutionID));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
