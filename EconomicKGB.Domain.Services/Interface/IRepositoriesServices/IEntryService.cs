using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IEntryService : IRepositoryServices<ProjectEntry>
    {
        Task<bool> SetEntry(IEnumerable<ProjectEntry> entryProjects, Int32 projectId);
        Task<IEnumerable<ProjectEntry>> GetAllEntry(Int32 projectId);
    }
}
