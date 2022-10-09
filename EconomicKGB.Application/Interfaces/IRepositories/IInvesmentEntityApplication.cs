using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IInvesmentEntityApplication : IRepositoryApplication<InvestmentEntityDto>
    {
        /// <summary>
        /// Get All the entities by SolutionId
        /// </summary>
        /// <param name="idSolution"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntityDto>> GetInvesmentEntitiesAsync(Int32 idSolution);

        /// <summary>
        /// Get  the invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<InvestmentEntityDto> GetInvesmentAsync(int projectId);

        /// <summary>
        /// Get All the invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntityDto>> GetInvesmentEntities(int projectId);

        /// <summary>
        /// Add one Invesment Entity to project
        /// </summary>
        /// <param name="entidadInvs"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetInvesmentEntityAsync(InvestmentEntityDto entidadInvs);
    }
}
