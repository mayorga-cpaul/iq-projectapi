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
        /// <summary>
        /// Set one entry async the entrtProject has the projectId
        /// </summary>
        /// <param name="entryProject"></param>
        /// <returns></returns>
        Task<bool> SetEntryAsync(ProjectEntry entryProject);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectEntry>> GetAllEntryAsync(Int32 projectId);
    }
}
