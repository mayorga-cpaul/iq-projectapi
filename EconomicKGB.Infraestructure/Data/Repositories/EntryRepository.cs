using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class EntryRepository : BaseRepository<ProjectEntry>, IEntryRepository
    {
        private readonly EconomicKGBContext repository;
        public EntryRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProjectEntry>> GetAllEntry(int projectId)
        {
            try
            {
                var data = await GetAsync(projectId);
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

        public async Task<bool> SetEntry(IEnumerable<ProjectEntry> entryProject, int projectId)
        {
            try
            {
                foreach (var item in entryProject)
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
