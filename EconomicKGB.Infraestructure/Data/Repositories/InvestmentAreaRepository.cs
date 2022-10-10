using Microsoft.EntityFrameworkCore;
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
                bool exist = await repository.AreaInversions.AnyAsync(e => e.ProjectId == projectId);

                if (exist)
                {
                    return repository.AreaInversions.Where(e => e.ProjectId == projectId);
                }
                else
                {
                    throw new Exception($"El proyecto con ID: {projectId} no existe");
                }

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
