using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IProjectApplication : IRepositoryApplication<ProjectDto>
    {
        /// <summary>
        /// Set many entries to one project
        /// </summary>
        /// <param name="ingresoProyectos"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetEntriesAsync(IEnumerable<ProjectEntryDto> ingresoProyectos, Int32 projectId);

        /// <summary>
        /// Get entries by project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectEntryDto>> GetEntriesAsync(Int32 projectId);

        /// <summary>
        /// Get projects by solution Id
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectDto>> GetProjectsBySolAsync(Int32 solution);
    }
}
