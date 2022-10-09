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
                var data = await GetAsync(projectId);
                if (data is null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                return await Task.FromResult(repository.CostProjects.Where(e => e.ProjectId == data.Id));
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
                : repository.CostProjects.Add(costProjects); await repository.SaveChangesAsync(); return true; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
