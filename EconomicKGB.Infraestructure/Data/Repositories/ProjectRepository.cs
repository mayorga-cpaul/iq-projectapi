using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly EconomicKGBContext repository;
        public ProjectRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProjectEntry>> GetEntriesAsync(Int32 project)
        {
            try
            {
                var data = await GetAsync(project);
                if (data is null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                return await Task.FromResult(repository.IngresoProyectos.Where(e => e.ProjectId == data.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Project>> GetProjectsBySolAsync(Int32 solution)
        {
            try
            {
                return await Task.FromResult(repository.Projects.Where(p => p.SolutionId == solution));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetEntriesAsync(IEnumerable<ProjectEntry> ingresoProyectos, Int32 project)
        {
            try
            {
                foreach (var item in ingresoProyectos)
                {
                    await repository.IngresoProyectos.AddAsync(item);
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
