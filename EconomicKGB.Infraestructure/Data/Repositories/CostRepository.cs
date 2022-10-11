using Microsoft.EntityFrameworkCore;
using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class CostRepository : BaseRepository<ProjectCost>, ICostRepository
    {
        private readonly EconomicKGBContext repository;
        public CostRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProjectCost>> GetAllCostAsync(int projectId)
        {
            try
            {
                bool exist = await repository.Projects.AnyAsync(e => e.Id == projectId);

                if (!exist)
                {
                    throw new Exception($"El proyecto con Id: {projectId} no existe");
                }

                return repository.ProjectCosts.Where(e => e.ProjectId == projectId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetCostAsync(ProjectCost costProjects)
        {
            try
            {
                _ = (repository.Projects.Any(e => e.Id == costProjects.ProjectId) is false)
                ? throw new Exception("El proyecto que desea asignarle al costo no existe")
                : repository.ProjectCosts.Add(costProjects); await repository.SaveChangesAsync(); return true; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
