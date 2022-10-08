using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Services.Interface.IRepositoriesServices
{
    public interface IProjectServices : IRepositoryServices<Project>
    {
        /// <summary>
        /// Set many entries to one project
        /// </summary>
        /// <param name="ingresoProyectos"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetEntriesAsync(IEnumerable<ProjectEntry> ingresoProyectos, Int32 projectId);
        
        /// <summary>
        /// Get entries by project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectEntry>> GetEntriesAsync(Int32 projectId);

        /// <summary>
        /// Get projects by solution Id
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsBySolAsync(Int32 solution);
    }
}
