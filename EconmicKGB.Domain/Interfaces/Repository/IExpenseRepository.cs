using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IExpenseRepository : IRepository<ProjectExpense>
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
        Task<IEnumerable<ProjectExpense>> GetAllExpenses(Int32 projectId);
    }
}
