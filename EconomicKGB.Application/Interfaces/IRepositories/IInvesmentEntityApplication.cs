using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IInvesmentEntityApplication : IRepositoryApplication<InvestmentEntityDto>
    {
        /// <summary>
        /// Get All the invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntityDto>> GetByProjectIdAsync(int projectId);
        /// <summary>
        /// Get All the entities by SolutionId
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntityDto>> GetBySolutionIdAsync(int solutionId);

        /// <summary>
        /// Get one invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<InvestmentEntityDto> GetOneInvesmentAsync(int projectId);

        /// <summary>
        /// Add one Invesment Entity to project
        /// </summary>
        /// <param name="entidadInvs"></param>
        /// <returns></returns>
        Task<bool> SetInvesmentEntityAsync(InvestmentEntityDto entidadInvs);

        /// <summary>
        /// Get Uniques names of the invesment
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<IEnumerable<UniqueName>> GetUniqueNames(int solutionId);
    }
}
