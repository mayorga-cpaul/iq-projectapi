using Dapper;
using Microsoft.EntityFrameworkCore;
using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using System.Data;
using System.Text.RegularExpressions;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class InvesmentEntityRepository : BaseRepository<InvestmentEntity>, IInvesmentEntityRepository
    {
        private readonly EconomicKGBContext repository;
        public InvesmentEntityRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
            
        }

        public async Task<InvestmentEntity> GetOneInvesmentAsync(int projectId)
        {
            try
            {
                bool exist = await repository.Projects
                    .AnyAsync(e => e.Id == projectId);

                if (exist)
                {
                    var invesment = (await repository.InvesmentEntity.
                        FirstOrDefaultAsync(e => e.ProjectId == projectId));
                    if (invesment is null)
                        throw new Exception($"Error, entidades no asignadas al proyecto con ID {projectId}");
                    return invesment;
                }
                else
                {
                    throw new Exception($"No existe proyecto con ID: {projectId}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<InvestmentEntity>> GetByProjectIdAsync(int projectId)
        {
            try
            {
                bool exist = await repository.Projects.AnyAsync(e => e.Id == projectId);

                if (exist)
                {
                    return repository.InvesmentEntity.Where(e => e.ProjectId == projectId);
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

        public async Task<IEnumerable<InvestmentEntity>> GetBySolutionIdAsync(int solutionId)
        {
            try
            {
                bool exists = await repository.Solutions.AnyAsync(e => e.Id == solutionId);

                if (!exists)
                {
                    throw new Exception($"La solución con ID: {solutionId} no existe"); 
                } 

                using (var connection = repository.Database.GetDbConnection())
                {
                    var result = await connection.QueryAsync<InvestmentEntity>("GetInvesments", new { solutionId = solutionId}, 
                        commandType: CommandType.StoredProcedure);
                    return result;
                }
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
                : repository.InvesmentEntity.Add(invesmentEnt); await repository.SaveChangesAsync(); return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UniqueName>> GetUniqueNames(int solutionId)
        {
            try
            {
                List<UniqueName> uniqueNames = new List<UniqueName>(); 
                bool exists = await repository.Solutions.AnyAsync(e => e.Id == solutionId);

                if (!exists)
                {
                    throw new Exception($"La solución con ID: {solutionId} no existe");
                }
                IEnumerable<string> getNames;
                using (var connection = repository.Database.GetDbConnection())
                {
                    getNames = await connection.QueryAsync<string>("GetUniqueNameInvesment", new { solutionId = solutionId },
                    commandType: CommandType.StoredProcedure);
                }
                foreach (var item in getNames)
                {
                    uniqueNames.Add(new UniqueName() { HasTrabajadoCon = item });
                }

                return uniqueNames;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
