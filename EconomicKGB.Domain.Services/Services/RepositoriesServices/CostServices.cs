using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Services.RepositoriesServices
{
    public class CostServices : BaseServices<ProjectCost>, ICostServices
    {
        private readonly ICostRepository costRepository;
        public CostServices(ICostRepository costRepository) : base(costRepository)
        {
            try
            {
                this.costRepository = costRepository;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<ProjectCost>> GetAllCost(int projectId)
        {
            try
            {
                return await costRepository.GetAllCost(projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SetCost(IEnumerable<ProjectCost> costProjects, int projectId)
        {
            try
            {
                return await costRepository.SetCost(costProjects, projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
