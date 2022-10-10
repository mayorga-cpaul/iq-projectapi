using AutoMapper;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class AssetApplication : IAssetApplication
    {
        private readonly IAssetServices assetApplication;
        private readonly IMapper mapper;

        public AssetApplication(IAssetServices assetApplication, IMapper mapper)
        {
            this.assetApplication = assetApplication;
            this.mapper = mapper;
        }

        public Task<int> CreateAsync(AssetDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int guid)
        {
            return await assetApplication.DeleteAsync(guid);
        }

        public async Task<IEnumerable<AssetDto>> GetAllAsync()
        {
            var projectExpense = await assetApplication.GetAllAsync();
            var projectExpenseDto = mapper.Map<IEnumerable<AssetDto>>(projectExpense);

            return projectExpenseDto;
        }

        public async Task<IEnumerable<AssetDto>> GetAllAssetAsync(int projectId)
        {
            var projectentry = await assetApplication.GetAllAsync();
            var projectentryDTO = mapper.Map<IEnumerable<AssetDto>>(projectentry);

            return projectentryDTO;
        }

        public async Task<AssetDto> GetAsync(int guid)
        {
            var projectExpense = await assetApplication.GetAsync(guid);
            var projectExpenseDto = mapper.Map<AssetDto>(projectExpense);

            return projectExpenseDto;
        }

        public async Task<bool> SetAssetAsync(AssetDto asset)
        {
            var projectEntry = mapper.Map<Domain.Entities.EntitiesBase.Asset>(asset);
            return await assetApplication.SetAssetAsync(projectEntry);
        }

        public async Task<bool> UpdateAsync(int id, AssetDto entity)
        {
            var economic = mapper.Map<Asset>(entity);
            economic.Id = id;
            return await assetApplication.UpdateAsync(economic);
        }
    }
}
