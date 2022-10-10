using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Services.Interface.IRepositoriesServices
{
    public interface IProjectServices : IRepositoryServices<Project>
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
        Task<bool> SetProjectToSolutionAsync(Project project);

        /// <summary>
        /// Get projects by solution Id
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsBySolAsync(Int32 solutionId);
    }
}
