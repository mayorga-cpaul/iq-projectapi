using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IExpenseRepository : IRepository<ProjectExpense>
    {
        /// <summary>
        /// Add many projectExpense to Project with the Id
        /// </summary>
        /// <param name="gastoProjects"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<bool> SetExpense(IEnumerable<ProjectExpense> gastoProjects, Int32 projectId);

        /// <summary>
        /// Get all the expenses
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectExpense>> GetAllExpenses(Int32 projectId);
    }
}
