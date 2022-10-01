using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IInvesmentAreaApplication : IRepositoryApplication<InvesmentAreaDto> 
    {
        /// <summary>
        /// Set many invesmentArea to Project
        /// </summary>
        /// <param name="inversionProyectos"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetInvesmentArea(IEnumerable<InvesmentAreaDto> inversionProyectos, Int32 projectId);

        /// <summary>
        /// Get All the invesmentArea Related to projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvesmentAreaDto>> GetProjects(Int32 projectId);
    }
}
