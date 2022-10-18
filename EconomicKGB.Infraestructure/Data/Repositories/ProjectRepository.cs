using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using Dapper;
using System.Data;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly EconomicKGBContext repository;
        public ProjectRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Project>> GetProjectsBySolAsync(Int32 solution)
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

        public async Task<int> LastCreated()
        {
            return await repository.Projects.MaxAsync(e => e.Id);
        }

        public async Task<bool> RemoveProject(int projectId)
        {

            using (var connection = repository.Database.GetDbConnection())
            {
                await connection.QueryAsync("RemoveProject", new { projectId = projectId },
                commandType: CommandType.StoredProcedure);
            }

            return true;
        }

        public async Task<bool> SetProjectToSolution(Project project)
        {
            try
            {
                _ = (repository.Solutions.Any(e => e.Id == project.SolutionId) is false)
              ? throw new Exception("El proyecto que desea asignarle al costo no existe")
              : repository.Projects.Add(project); await repository.SaveChangesAsync(); return true;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
