using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IInvesmentAreaServices : IRepositoryServices<InvesmentArea>
    {
        /// <summary>
        /// Set one invesmentArea to Project
        /// </summary>
        /// <param name="inversionProyectos"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetInvesmentArea(InvesmentArea invesmentArea);

        /// <summary>
        /// Get All the invesmentArea Related to projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvesmentArea>> GetProjects(Int32 projectId);
    }
}
