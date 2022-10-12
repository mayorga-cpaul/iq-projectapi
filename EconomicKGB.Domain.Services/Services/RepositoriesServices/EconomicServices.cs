using SmartSolution.Domain.Entities.Economics;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Domain.Services.Services.RepositoriesServices
{
    public class EconomicServices : BaseServices<Economic>, IEconomicServices
    {
        private readonly IEconomicRepository economicRepository;
        public EconomicServices(IEconomicRepository economicRepository)
            : base(economicRepository)
        {
            try
            {
                this.economicRepository = economicRepository;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public async Task<int> CreateCashFlowsAsync(List<Economic> economicClasses, int nper)
        //{
        //    try
        //    {
        //        return await economicRepository.CreateCashFlowAsync(economicClasses, nper);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        public async Task<IEnumerable<Economic>> FindByUserEmailAsync(string email)
        {
            try
            {
                return await economicRepository.FindByUserEmailAsync(email);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Economic>> GetAnualidadesAsync(int solutionId)
        {
            try
            {
                return await economicRepository.GetAnualidadesAsync(solutionId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Economic>> GetEconomicBySolutionAsync(int solutionId)
        {
            try
            {
                return await economicRepository.GetEconomicBySolutionAsync(solutionId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Economic>> GetInteresAsync(int solutionId)
        {
            try
            {
                return await economicRepository.GetInteresAsync(solutionId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
