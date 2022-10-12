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
    public class FlujoCajaServices : BaseServices<FlujoDeCaja>, IFlujoCajaServices
    {
        private readonly IFlujoDeCajaRepository flujoDeCajaRepository;
        public FlujoCajaServices(IFlujoDeCajaRepository flujoDeCajaRepository)
            : base(flujoDeCajaRepository)
        {
            this.flujoDeCajaRepository = flujoDeCajaRepository;
        }

        public async Task<IEnumerable<FlujoDeCaja>> GetBySolutionID(int solutionID)
        {
            try
            {
                return await flujoDeCajaRepository.GetBySolutionID(solutionID);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
