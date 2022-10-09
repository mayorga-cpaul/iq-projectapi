using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IEntryApplication : IRepositoryApplication<ProjectEntryDto>
    {
        /// <summary>
        /// Set one entry async the entrtProject has the projectId
        /// </summary>
        /// <param name="entryProject"></param>
        /// <returns></returns>
        Task<bool> SetEntryAsync(ProjectEntryDto entryProject);

        /// <summary>
        /// Get all the projectCost by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectEntryDto>> GetAllEntryAsync(Int32 projectId);
    }
}
