using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IProjectApplication : IRepositoryApplication<ProjectDto>
    {
        /// <summary>
        /// get the last Id of the project
        /// </summary>
        /// <returns></returns>
        Task<int> LastCreated();
        /// <summary>
        /// Set one project to solution
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Task<bool> SetProjectToSolutionAsync(ProjectDto project);
        /// <summary>
        /// Get projects by solution Id
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectDto>> GetProjectsBySolAsync(Int32 solutionId);
    }
}
