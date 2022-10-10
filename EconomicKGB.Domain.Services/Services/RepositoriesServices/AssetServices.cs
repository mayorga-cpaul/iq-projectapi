using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Services.RepositoriesServices
{
    public class AssetServices : BaseServices<Asset>, IAssetServices
    {
        private readonly IAssetRepository assetRepository;
        public AssetServices(IAssetRepository assetRepository) : base(assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        public async Task<IEnumerable<Asset>> GetAllAssetAsync(int projectId)
        {
            return await assetRepository.GetAllAssetAsync(projectId);
        }

        public async Task<bool> SetAssetAsync(Asset asset)
        {
            return await assetRepository.SetAssetAsync(asset);
        }
    }
}
