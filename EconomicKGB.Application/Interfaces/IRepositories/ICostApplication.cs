using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface ICostApplication : IRepositoryApplication<ProjectCostDto>
    {

        /// <summary>
        /// Add one Project cost don't forget that CostProject has the projectId
        /// </summary>
        /// <param name="costProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetCostAsync(ProjectCostDto costProjects);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectCostDto>> GetAllCostAsync(Int32 projectId);
    }
}
