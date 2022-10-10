using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IAssetRepository : IRepository<Asset>
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
