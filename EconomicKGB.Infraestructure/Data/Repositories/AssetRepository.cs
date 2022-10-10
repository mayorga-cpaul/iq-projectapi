using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        private readonly EconomicKGBContext repository;
        public AssetRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Asset>> GetAllAssetAsync(int projectId)
        {
            var data = await GetAsync(projectId);

            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return repository.Assets.Where(e => e.ProjectId == data.Id);
        }

        public async Task<bool> SetAssetAsync(Asset asset)
        {
            try
            {
                _ = (repository.Projects.Any(e => e.Id == asset.ProjectId) is false)
             ? throw new Exception("El proyecto que desea asignarle al costo no existe")
             : repository.Assets.Add(asset); await repository.SaveChangesAsync(); return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
