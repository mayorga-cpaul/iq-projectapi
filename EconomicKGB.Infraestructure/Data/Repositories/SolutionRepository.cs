using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class SolutionRepository : BaseRepository<Solution>, ISolutionRepository
    {
        private readonly EconomicKGBContext repository;
        public SolutionRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(Int32 solution)
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

        public async Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario)
        {
            try
            {
                return await Task.FromResult(repository.Solutions.Where(e => e.UserId == usuario));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Solution> GetSolutionByIdAsync(Int32 id)
        {
            try
            {
                if (id < 0)
                {
                    throw new Exception("null");
                }

                var data = repository.Solutions.Find(id);
                if (data is null)
                {
                    throw new Exception("null");
                }

                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Boolean> SetOneProjectToSolutionAsync(Int32 project, Int32 solution)
        {
            try
            {
                var data = await repository.Projects.FirstOrDefaultAsync(e => e.Id == project);
                if (data is null)
                {
                    throw new Exception("DX");
                }
                repository.Projects.Add(data);
                return await Task.FromResult((repository.SaveChanges() > 0) ? true : false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetProjectToSolutionAsync(IEnumerable<Project> projects, Int32 solution)
        {
            foreach (var item in projects)
            {
                if (item.Solution.Id != solution)
                {
                    throw new Exception("Error al asignar proyecto a solution");
                }
                repository.Projects.Add(item);
            }

            return await Task.FromResult((repository.SaveChanges() > 0) ? true : false);
        }
    }
}
