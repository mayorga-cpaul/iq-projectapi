using AutoMapper;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class ProjectApplication : IProjectApplication
    {
        private readonly IProjectServices projectServices;
        private readonly IMapper mapper;

        public ProjectApplication(IProjectServices projectServices, IMapper mapper)
        {
            this.projectServices = projectServices;
            this.mapper = mapper;
        }

        public async Task<Int32> CreateAsync(ProjectDto entity)
        {
            var project = mapper.Map<Project>(entity);
            return await projectServices.CreateAsync(project);
        }

        public async Task<Int32> DeleteAsync(Int32 projectId)
        {
            return await projectServices.DeleteAsync(projectId);
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await projectServices.GetAllAsync();
            var projectsDto = mapper.Map<IEnumerable<ProjectDto>>(projects);
            return projectsDto;
        }


        public async Task<ProjectDto> GetAsync(Int32 projectId)
        {
            var project = await projectServices.GetAsync(projectId);
            var projectDto = mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public Task<IEnumerable<ProjectEntry>> GetEntriesAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectsAsync(int solution)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetEntriesAsync(IEnumerable<ProjectEntry> ingresoProyectos, int projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int id, ProjectDto entity)
        {
            var project = mapper.Map<Project>(entity);
            project.Id = id;
            return await projectServices.UpdateAsync(project);
        }
    }
}
