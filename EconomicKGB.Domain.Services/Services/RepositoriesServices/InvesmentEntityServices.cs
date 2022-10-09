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

        public async Task<InvestmentEntity> GetInvesmentEntities(int projectId)
        {
            try
            {
                return await invesmentEntityRepository.GetInvesmentEntities(projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<InvestmentEntity>> GetInvesmentEntity(int idSolution)
        {
            try
            {
                return await invesmentEntityRepository.GetInvesmentEntity(idSolution);
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
    }
}
