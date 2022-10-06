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
        Task<bool> SetEntryAsync(IEnumerable<ProjectEntryDto> entryProjects, Int32 projectId);
        Task<IEnumerable<ProjectEntryDto>> GetAllEntryAsync(Int32 projectId);
    }
}
