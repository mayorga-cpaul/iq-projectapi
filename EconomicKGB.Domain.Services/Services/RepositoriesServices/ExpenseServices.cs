using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Services.RepositoriesServices
{
    public class ExpenseServices : BaseServices<ProjectExpense>, IExpenseServices
    {
        private readonly IExpenseRepository expenseRepository;
        public ExpenseServices(IExpenseRepository expenseRepository) : base(expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<ProjectExpense>> GetAllExpensesAsync(int projectId)
        {
            try
            {
                return await expenseRepository.GetAllExpenses(projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SetExpenseAsync(ProjectExpense gastoProjects)
        {
            try
            {
                return await expenseRepository.SetExpenseAsync(gastoProjects);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
