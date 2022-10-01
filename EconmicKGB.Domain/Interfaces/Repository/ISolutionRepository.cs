using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface ISolutionRepository : IRepository<Solution>
    {
        Task<Boolean> SetProjectToSolutionAsync(IEnumerable<Project> projects, Int32 solution);
        Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario);
        Task<Solution> GetSolutionByIdAsync(Int32 id);
        Task<Boolean> SetOneProjectToSolutionAsync(Int32 project, Int32 solution);
        Task<IEnumerable<Project>> GetAllProjectsAsync(Int32 solution);
    }
}
