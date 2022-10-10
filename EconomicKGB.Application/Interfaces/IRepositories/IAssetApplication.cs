using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IAssetApplication : IRepositoryApplication<AssetDto>
    {
        /// <summary>
        /// Set one Asset async 
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        Task<bool> SetAssetAsync(AssetDto asset);

        /// <summary>
        /// Get all the Asset by ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssetDto>> GetAllAssetAsync(Int32 projectId);
    }
}
