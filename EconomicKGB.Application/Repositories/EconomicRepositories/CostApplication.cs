using AutoMapper;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class CostApplication : ICostApplication
    {
        private readonly ICostServices costServices;
        private readonly IMapper mapper;

        public CostApplication(ICostServices costServices, IMapper mapper)
        {
            this.costServices = costServices;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(ProjectCostDto entity)
        {
            var projectCost = mapper.Map<ProjectCost>(entity);
            return await costServices.CreateAsync(projectCost);
        }

        public async Task<int> DeleteAsync(int guid)
        {
            return await costServices.DeleteAsync(guid);
        }

        public async Task<IEnumerable<ProjectCostDto>> GetAllAsync()
        {
            var projectCost = await costServices.GetAllAsync();    
            var projectCostDto = mapper.Map<IEnumerable<ProjectCostDto>>(projectCost);

            return projectCostDto;
        }

        public async Task<IEnumerable<ProjectCostDto>> GetAllCostAsync(int projectId)
        {
            var projectCost = await costServices.GetAllCost(projectId);
            var projectCostDto = mapper.Map<IEnumerable<ProjectCostDto>>(projectCost);

            return projectCostDto;
        }

        public async Task<ProjectCostDto> GetAsync(int guid)
        {
            var projectCost = await costServices.GetAsync(guid);
            var projectCostDto = mapper.Map<ProjectCostDto>(projectCost);
            return projectCostDto;
        }

        public async Task<bool> SetCostAsync(IEnumerable<ProjectCostDto> costProjects, int projectId)
        {
            var projectCost = mapper.Map<IEnumerable<ProjectCost>>(costProjects);
            return await costServices.SetCost(projectCost, projectId);
        }

        public async Task<bool> UpdateAsync(int id, ProjectCostDto entity)
        {
            var projectCost = mapper.Map<ProjectCost>(entity);
            projectCost.Id = id;
            return await costServices.UpdateAsync(projectCost);
        }
    }
}
