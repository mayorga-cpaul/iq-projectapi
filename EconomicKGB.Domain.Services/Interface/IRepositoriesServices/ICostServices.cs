using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface ICostServices : IRepositoryServices<ProjectCost>
    {
        /// <summary>
        /// Add one Project cost don't forget that CostProject has the projectId
        /// </summary>
        /// <param name="costProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetCostAsync(ProjectCost costProjects);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectCost>> GetAllCostAsync(Int32 projectId);
    }
}
