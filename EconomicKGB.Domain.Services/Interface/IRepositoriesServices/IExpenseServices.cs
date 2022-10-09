using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IExpenseServices : IRepositoryServices<ProjectExpense>
    {
        /// <summary>
        /// Add one ProjectExpense to the project 
        /// </summary>
        /// <param name="gastoProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetExpenseAsync(ProjectExpense projectExpense);

        /// <summary>
        /// Get all the expenses
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectExpense>> GetAllExpensesAsync(Int32 projectId);
    }
}
