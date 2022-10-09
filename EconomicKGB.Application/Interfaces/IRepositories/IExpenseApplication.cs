using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IExpenseApplication : IRepositoryApplication<ProjectExpenseDto>
    {
        /// <summary>
        /// Add one ProjectExpense to the project 
        /// </summary>
        /// <param name="gastoProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetExpenseAsync(ProjectExpenseDto projectExpense);

        /// <summary>
        /// Get all the expenses
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectExpenseDto>> GetAllExpenses(Int32 projectId);
    }
}
