using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Services.RepositoriesServices
{
    public class InvesmentEntityServices : BaseServices<InvestmentEntity>, IInvesmentEntityServices
    {
        private readonly IInvesmentEntityRepository invesmentEntityRepository;
        public InvesmentEntityServices(IInvesmentEntityRepository invesmentEntityRepository) : base(invesmentEntityRepository)
        {
            this.invesmentEntityRepository = invesmentEntityRepository;
        }

        public async Task<InvestmentEntity> GetOneInvesmentAsync(int projectId)
        {
            try
            {
                return await invesmentEntityRepository.GetOneInvesmentAsync(projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<InvestmentEntity>> GetByProjectIdAsync(int projectId)
        {
            return await invesmentEntityRepository.GetByProjectIdAsync(projectId);
        }

        public async Task<IEnumerable<InvestmentEntity>> GetBySolutionIdAsync(int idSolution)
        {
            try
            {
                return await invesmentEntityRepository.GetBySolutionIdAsync(idSolution);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SetInvesmentEntityAsync(InvestmentEntity entidadInvs)
        {
            try
            {
                return await invesmentEntityRepository.SetInvesmentEntityAsync(entidadInvs);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<UniqueName>> GetUniqueNames(int solutionId)
        {
            try
            {
                return await invesmentEntityRepository.GetUniqueNames(solutionId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
