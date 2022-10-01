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

        public async Task<bool> SetInvesmentArea(IEnumerable<InvesmentArea> inversionProyectos, int projectId)
        {
            try
            {
                foreach (var item in inversionProyectos)
                {
                    repository.AreaInversions.Add(item);
                }
                return await Task.FromResult((repository.SaveChanges() > 0) ? true : false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
