using AutoMapper;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class InvesmentEntityApplication : IInvesmentEntityApplication
    {
        private readonly IInvesmentEntityServices repository;
        private readonly IMapper mapper;

        public InvesmentEntityApplication(IInvesmentEntityServices repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(InvestmentEntityDto entity)
        {
            var investmentEntity = mapper.Map<InvestmentEntity>(entity);
            return await repository.CreateAsync(investmentEntity);
        }

        public async Task<int> DeleteAsync(int guid)
        {
            return await repository.DeleteAsync(guid);
        }

        public async Task<IEnumerable<InvestmentEntityDto>> GetAllAsync()
        {
            var invesmentEntities = await repository.GetAllAsync();
            var invesmentEntitiesDto = mapper.Map<IEnumerable<InvestmentEntityDto>>(invesmentEntities);

            return invesmentEntitiesDto;
        }

        public async Task<InvestmentEntityDto> GetAsync(int guid)
        {
            var investmentEntity = await repository.GetAsync(guid);
            var investmentEntityDto = mapper.Map<InvestmentEntityDto>(investmentEntity);
            return investmentEntityDto;
        }

        public async Task<InvestmentEntityDto> GetInvesmentAsync(int projectId)
        {
            var invesments = await repository.GetInvesmentEntities(projectId);
            return mapper.Map<InvestmentEntityDto>(invesments);
        }

        public async Task<IEnumerable<InvestmentEntityDto>> GetInvesmentEntities(int idSolution)
        {
            var invesmentEntities = await repository.GetInvesmentEntities(idSolution);
            return mapper.Map<IEnumerable<InvestmentEntityDto>>(invesmentEntities);
        }

        public async Task<bool> SetInvesmentEntity(IEnumerable<InvestmentEntityDto> entidadInvs, int projectId)
        {
            var invesmentEntities = mapper.Map<IEnumerable<InvestmentEntity>>(entidadInvs);
            return await repository.SetInvesmentEntity(invesmentEntities, projectId);
        }

        public async Task<bool> UpdateAsync(int id, InvestmentEntityDto entity)
        {
            var investmentEntity = mapper.Map<InvestmentEntity>(entity);
            investmentEntity.Id = id;
            return await repository.UpdateAsync(investmentEntity);
        }
    }
}
