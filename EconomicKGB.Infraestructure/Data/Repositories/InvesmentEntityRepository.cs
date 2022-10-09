using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class InvesmentEntityRepository : BaseRepository<InvestmentEntity>, IInvesmentEntityRepository
    {
        private readonly EconomicKGBContext repository;
        public InvesmentEntityRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<InvestmentEntity> GetInvesmentEntities(int projectId)
        {
            try
            {
                var data = repository.EntidadInvs.FindAsync(projectId);

                if (data.Result is null)
                {
                    throw new Exception("Couldn't find the object");
                }

                return await Task.FromResult(data.Result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<InvestmentEntity>> GetInvesmentEntity(int idSolution)
        {
            try
            {
                List<InvestmentEntity> entidadInvs = new List<InvestmentEntity>();

                foreach (var item in GetProjectBySolution(idSolution).Result)
                {
                    entidadInvs.AddRange(repository.EntidadInvs.Where(e => e.ProjectId == item.Id));
                }
                return await Task.FromResult(entidadInvs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetInvesmentEntityAsync(InvestmentEntity invesmentEnt)
        {
            try
            {
                _ = (repository.Projects.Any(e => e.Id == invesmentEnt.ProjectId) is false)
                ? throw new Exception("El proyecto que desea asignarle al costo no existe")
                : repository.EntidadInvs.Add(invesmentEnt); await repository.SaveChangesAsync(); return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<Project>> GetProjectBySolution(Int32 solution)
        {
            try
            {
                return await Task.FromResult(repository.Projects.Where(p => p.SolutionId == solution));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
