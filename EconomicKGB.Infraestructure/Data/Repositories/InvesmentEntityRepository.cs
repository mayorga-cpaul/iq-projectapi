using Microsoft.EntityFrameworkCore;
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

        public async Task<InvestmentEntity> GetInvesment(int projectId)
        {
            try
            {
                bool exist = await repository.EntidadInvs
                    .AnyAsync(e => e.ProjectId == projectId);

                if (exist)
                {
                    var invesment = (await repository.EntidadInvs.
                        FirstOrDefaultAsync(e => e.ProjectId == projectId));
                    if (invesment is null)
                        throw new Exception("La entidad inversora no existe");
                    return invesment;
                }
                else
                {
                    throw new Exception("La entidad inversora no existe");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<InvestmentEntity>> GetInvesmentEntities(int projectId)
        {
            try
            {
                bool exist = await repository.Projects.AnyAsync(e => e.Id == projectId);

                if (exist)
                {
                    return repository.EntidadInvs.Where(e => e.ProjectId == projectId);
                }
                else
                {
                    throw new Exception("Error");
                }
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

                foreach (var item in await GetProjectBySolution(idSolution))
                {
                    entidadInvs.AddRange(repository.EntidadInvs.Where(e => e.ProjectId == item.Id));
                }

                return entidadInvs;
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
