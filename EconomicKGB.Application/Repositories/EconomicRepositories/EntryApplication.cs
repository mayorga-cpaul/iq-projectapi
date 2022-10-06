using AutoMapper;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Services.Interface.IRepositoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class EntryApplication : IEntryApplication
    {
        private readonly IEntryService entryservices;
        private readonly IMapper mapper;

        public EntryApplication(IEntryService entryservices, IMapper mapper)
        {
            this.entryservices = entryservices;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(ProjectEntryDto entity)
        {
            var projectentry = mapper.Map<ProjectEntry>(entity);
            return await entryservices.CreateAsync(projectentry);
        }

        public async Task<int> DeleteAsync(int guid)
        {
            return await entryservices.DeleteAsync(guid);
        }

        public async Task<IEnumerable<ProjectEntryDto>> GetAllAsync()
        {
            var projectentry = await entryservices.GetAllAsync();
            var projectentryDTO = mapper.Map<IEnumerable<ProjectEntryDto>>(projectentry);

            return projectentryDTO;
        }
        public async Task<IEnumerable<ProjectEntryDto>> GetAllEntryAsync(int projectId)
        {
            var projectentry = await entryservices.GetAllEntry(projectId);
            var projectentryDTO = mapper.Map<IEnumerable<ProjectEntryDto>>(projectentry);

            return projectentryDTO;
        }

        public async Task<ProjectEntryDto> GetAsync(int guid)
        {
            var projectEntry = await entryservices.GetAsync(guid);
            var projectEntryDTO = mapper.Map<ProjectEntryDto>(projectEntry);
            return projectEntryDTO;
        }

        public async Task<bool> SetEntryAsync(IEnumerable<ProjectEntryDto> entryProjects, int projectId)
        {
            var projectEntry = mapper.Map<IEnumerable<ProjectEntry>>(entryProjects);
            return await entryservices.SetEntry(projectEntry, projectId);
        }

        public async Task<bool> UpdateAsync(int id, ProjectEntryDto entity)
        {
            var projectEntry = mapper.Map<ProjectEntry>(entity);
            projectEntry.Id = id;
            return await entryservices.UpdateAsync(projectEntry);
        }
    }
}
