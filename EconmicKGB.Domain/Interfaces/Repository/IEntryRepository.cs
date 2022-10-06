using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IEntryRepository: IRepository<ProjectEntry>
    {
        Task<bool> SetEntry(IEnumerable<ProjectEntry> entryProject, Int32 projectId);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectEntry>> GetAllEntry(Int32 projectId);
    }
}
