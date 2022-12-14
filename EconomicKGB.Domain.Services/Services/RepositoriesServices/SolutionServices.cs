using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Domain.Services.Services.RepositoriesServices
{
    public class SolutionServices : BaseServices<Solution>, ISolutionServices
    {
        private readonly ISolutionRepository solutionRepository;

        public SolutionServices(ISolutionRepository solutionRepository) : base(solutionRepository)
        {
            this.solutionRepository = solutionRepository;
        }

        public async Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario)
        {
            try
            {
                return await solutionRepository.GetByUserAsync(usuario);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Solution>> GetByUserEmailAsync(string email)
        {
            try
            {
                return await solutionRepository.GetByUserEmailAsync(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Solution> GetSolutionByIdAsync(Int32 id)
        {
            try
            {
                return await solutionRepository.GetSolutionByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> LastCreatedAsync()
        {
            return await solutionRepository.LastCreatedAsync();
        }

        public async Task<bool> SetSolutionToUser(Solution solution)
        {
            return await solutionRepository.SetSolutionToUser(solution);
        }
    }
}
