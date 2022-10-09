using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<bool> SetProjectToSolution(Project project);
        /// <summary>
        /// Get projects by solution Id
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsBySolAsync(Int32 solutionId);
        /// <summary>
        /// Get all the projects by solution id
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetAllProjectsAsync(Int32 solutionId);
    }
}
