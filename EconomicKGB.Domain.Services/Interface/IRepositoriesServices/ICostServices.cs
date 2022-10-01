using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface ICostServices : IRepositoryServices<ProjectCost>
    {
        /// <summary>
        /// Add many costProjects to Project
        /// </summary>
        /// <param name="costProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetCost(IEnumerable<ProjectCost> costProjects, Int32 projectId);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectCost>> GetAllCost(Int32 projectId);
    }
}
