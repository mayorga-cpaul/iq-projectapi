using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IAssetServices : IRepositoryServices<Asset>
    {
        /// <summary>
        /// Set one Asset async 
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        Task<bool> SetAssetAsync(Asset asset);

        /// <summary>
        /// Get all the Asset by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<Asset>> GetAllAssetAsync(Int32 projectId);
    }
}
