using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Services.Interface.IRepositoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Services.Services.RepositoriesServices
{
    public class EntryService : BaseServices<ProjectEntry>, IEntryService
    {
        private readonly IEntryRepository entryRepository;
        public EntryService(IEntryRepository entryRepository) : base(entryRepository)
        {
            try
            {
                this.entryRepository = entryRepository;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProjectEntry>> GetAllEntry(int projectId)
        {
            try
            {
                return await entryRepository.GetAllEntry(projectId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetEntry(IEnumerable<ProjectEntry> entryProjects, int projectId)
        {
            try
            {
                return await entryRepository.SetEntry(entryProjects, projectId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
