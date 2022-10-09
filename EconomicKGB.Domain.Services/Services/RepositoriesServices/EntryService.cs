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

        public async Task<IEnumerable<ProjectEntry>> GetAllEntryAsync(int projectId)
        {
            try
            {
                return await entryRepository.GetAllEntryAsync(projectId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetEntryAsync(ProjectEntry entryProjects)
        {
            try
            {
                return await entryRepository.SetEntryAsync(entryProjects);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
