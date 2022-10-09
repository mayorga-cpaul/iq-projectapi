using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly EconomicKGBContext repository;
        public ProjectRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(int solutionId)
        {
            try
            {
                if (!await repository.Solutions.AnyAsync(e => e.Id == solutionId))
                    throw new Exception("El usuario no existe");
                return await Task.FromResult(repository.Projects.Where(p => p.SolutionId == solutionId));
            }
            catch (Exception)
            {
                throw;
            }
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

        public async Task<bool> SetProjectToSolution(Project project)
        {
            try
            {
                //if (repository.Solutions.Any(e => e.Id == project.SolutionId))
                //{
                //    await repository.Projects.AddAsync(project);
                //    await repository.SaveChangesAsync();
                //    return true;
                //}
                //else
                //    throw new Exception("El proyecto que desea asignarle al costo no existe");


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
