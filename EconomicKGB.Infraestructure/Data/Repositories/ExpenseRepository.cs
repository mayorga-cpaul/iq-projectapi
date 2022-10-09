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
                return await Task.FromResult(repository.GastoProjects.Where(e => e.ProjectId == projectId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetExpenseAsync(ProjectExpense projectExpense)
        {
            try
            {
                _ = (repository.Projects.Any(e => e.Id == projectExpense.ProjectId) is false)
                ? throw new Exception("El proyecto que desea asignarle al costo no existe")
                : repository.GastoProjects.Add(projectExpense); await repository.SaveChangesAsync(); return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
