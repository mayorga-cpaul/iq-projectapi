using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IExpenseApplication : IRepositoryApplication<ProjectExpenseDto>
    {
        /// <summary>
        /// Add many projectExpense to Project with the Id
        /// </summary>
        /// <param name="gastoProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetExpenseAsync(IEnumerable<ProjectExpenseDto> gastoProjects, Int32 projectId);

        /// <summary>
        /// Get all the expenses
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectExpenseDto>> GetAllExpenses(Int32 projectId);
    }
}
