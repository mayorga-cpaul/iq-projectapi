using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IInvesmentEntityServices : IRepositoryServices<InvestmentEntity>
    {
        /// <summary>
        /// Get All the entities by SolutionId
        /// </summary>
        /// <param name="idSolution"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntity>> GetInvesmentEntity(Int32 idSolution);

        /// <summary>
        /// Get  the invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<InvestmentEntity> GetInvesment(int projectId);

        /// <summary>
        /// Get All the invesment by projectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<InvestmentEntity>> GetInvesmentEntities(int projectId);

        /// <summary>
        /// Add one Invesment Entity to project
        /// </summary>
        /// <param name="entidadInvs"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetInvesmentEntityAsync(InvestmentEntity entidadInvs);

    }
}
