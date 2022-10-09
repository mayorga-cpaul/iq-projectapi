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

        public async Task<IEnumerable<ProjectCost>> GetAllCostAsync(int projectId)
        {
            try
            {
                return await costRepository.GetAllCostAsync(projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SetCostAsync(ProjectCost costProjects)
        {
            try
            {
                return await costRepository.SetCostAsync(costProjects);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
