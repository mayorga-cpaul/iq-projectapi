using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Services.Interface.IRepositoriesServices
{
    public interface ISolutionServices : IRepositoryServices<Solution>
    {
        Task<bool> SetProjectToSolutionAsync(IEnumerable<Project> projects, Int32 solution);
        Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario);
        Task<IEnumerable<Solution>> GetByUserEmailAsync(string email);
        Task<Solution> GetSolutionByIdAsync(Int32 id);
        Task<bool> SetOneProjectToSolutionAsync(Int32 project, Int32 solution);
        Task<IEnumerable<Project>> GetAllProjectsAsync(Int32 solution);
    }
}
