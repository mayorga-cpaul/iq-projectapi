using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface ICostApplication : IRepositoryApplication<ProjectCostDto>
    {
        
        /// <summary>
        /// Add many costProjects to Project
        /// </summary>
        /// <param name="costProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetCostAsync(IEnumerable<ProjectCostDto> costProjects, Int32 projectId);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectCostDto>> GetAllCostAsync(Int32 projectId);
    }
}
