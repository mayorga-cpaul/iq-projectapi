using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IInvesmentEntityServices : IRepositoryServices<InvestmentEntity>
    {
        /// <summary>
        /// Get All the invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntity>> GetByProjectIdAsync(int projectId);
        /// <summary>
        /// Get All the entities by SolutionId
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntity>> GetBySolutionIdAsync(int solutionId);

        /// <summary>
        /// Get one invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<InvestmentEntity> GetOneInvesmentAsync(int projectId);

        /// <summary>
        /// Add one Invesment Entity to project
        /// </summary>
        /// <param name="entidadInvs"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetInvesmentEntityAsync(InvestmentEntity entidadInvs);

        /// <summary>
        /// Get Uniques names of the invesment
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<UniqueName>> GetUniqueNames(int solutionId);

    }
}
