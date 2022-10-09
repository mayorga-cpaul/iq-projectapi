using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class InvestmentAreaRepository : BaseRepository<InvesmentArea>, IInvestmentAreaRepository
    {
        private readonly EconomicKGBContext repository;
        public InvestmentAreaRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<InvesmentArea>> GetProjects(int projectId)
        {
            try
            {
                return await Task.FromResult(repository.AreaInversions.Where(e => e.ProjectId == projectId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetInvesmentArea(InvesmentArea invesmentArea)
        {
            try
            {
                _ = (repository.Projects.Any(e => e.Id == invesmentArea.ProjectId) is false)
                ? throw new Exception("El proyecto que desea asignarle al costo no existe")
                : repository.AreaInversions.Add(invesmentArea); await repository.SaveChangesAsync(); return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
