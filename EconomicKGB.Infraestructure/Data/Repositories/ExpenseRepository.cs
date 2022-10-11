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
                bool exist = await repository.Projects.AnyAsync(e => e.Id == projectId);

                if (!exist)
                {
                    throw new Exception($"El proyecto con Id: {projectId} no existe");
                }                

                return repository.ProjectExpenses.Where(e => e.ProjectId == projectId);
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
                : repository.ProjectExpenses.Add(projectExpense); await repository.SaveChangesAsync(); return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
