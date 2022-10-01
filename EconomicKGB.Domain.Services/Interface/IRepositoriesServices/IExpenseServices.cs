using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IExpenseServices : IRepositoryServices<ProjectExpense>
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
