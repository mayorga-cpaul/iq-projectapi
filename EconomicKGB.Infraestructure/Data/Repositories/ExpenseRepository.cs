using Microsoft.EntityFrameworkCore;
using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class ExpenseRepository : BaseRepository<ProjectExpense>, IExpenseRepository
    {
        private readonly EconomicKGBContext repository;
        public ExpenseRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProjectExpense>> GetAllExpenses(int projectId)
        {
            try
            {
                var data = await GetAsync(projectId);
                if (data is null)
                {
                    throw new ArgumentNullException(nameof(data));
                }
                return await Task.FromResult(repository.GastoProjects.Where(e => e.ProjectId == data.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetExpense(IEnumerable<ProjectExpense> gastoProjects, int projectId)
        {
            try
            {
                var existingItem = await GetAsync(projectId);

                if (existingItem is null)
                {
                    return false;
                }
                else
                {
                    foreach (var item in gastoProjects)
                    {
                        await repository.GastoProjects.AddAsync(item);
                    }
                }

                return await Task.FromResult((repository.SaveChanges() > 0) ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
