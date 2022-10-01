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

        public async Task<IEnumerable<ProjectCost>> GetAllCost(int projectId)
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

        public async Task<bool> SetCost(IEnumerable<ProjectCost> costProjects, int projectId)
        {
            try
            {
                foreach (var item in costProjects)
                {
                    await repository.CostProjects.AddAsync(item);
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
