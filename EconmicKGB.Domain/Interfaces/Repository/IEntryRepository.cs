using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IEntryRepository: IRepository<ProjectEntry>
    {
        /// <summary>
        /// Set one entry async the entrtProject has the projectId
        /// </summary>
        /// <param name="entryProject"></param>
        /// <returns></returns>
        Task<bool> SetEntryAsync(ProjectEntry entryProject);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectEntry>> GetAllEntryAsync(Int32 projectId);
    }
}
