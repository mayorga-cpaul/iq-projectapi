using AutoMapper;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class InvesmentAreaApplication : IInvesmentAreaApplication
    {
        private readonly IInvesmentAreaServices repository;
        private readonly IMapper mapper;

        public InvesmentAreaApplication(IInvesmentAreaServices invesmentAreaServices, IMapper mapper)
        {
            this.repository = invesmentAreaServices;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(InvesmentAreaDto entity)
        {
            var projectCost = mapper.Map<InvesmentArea>(entity);
            return await repository.CreateAsync(projectCost);
        }

        public async Task<int> DeleteAsync(int guid)
        {
            return await repository.DeleteAsync(guid);
        }

        public async Task<IEnumerable<InvesmentAreaDto>> GetAllAsync()
        {
            var InvesmentArea = await repository.GetAllAsync();
            var invesmentAreaDto = mapper.Map<IEnumerable<InvesmentAreaDto>>(InvesmentArea);

            return invesmentAreaDto;
        }

        public async Task<InvesmentAreaDto> GetAsync(int guid)
        {
            var invesmentArea = await repository.GetAsync(guid);
            var invesmentAreaDto = mapper.Map<InvesmentAreaDto>(invesmentArea);
            return invesmentAreaDto;
        }

        public async Task<IEnumerable<InvesmentAreaDto>> GetProjects(int projectId)
        {
            var invesmentAreas = await repository.GetProjects(projectId);
            return mapper.Map<IEnumerable<InvesmentAreaDto>>(invesmentAreas);
        }

        public async Task<bool> SetInvesmentArea(InvesmentAreaDto inversionProyectos)
        {
            var invesmentAreas = mapper.Map<InvesmentArea>(inversionProyectos);
            return await repository.SetInvesmentArea(invesmentAreas);
        }

        public async Task<bool> UpdateAsync(int id, InvesmentAreaDto entity)
        {
            var invesmentArea = mapper.Map<InvesmentArea>(entity);
            invesmentArea.Id = id;
            return await repository.UpdateAsync(invesmentArea);
        }
    }
}
