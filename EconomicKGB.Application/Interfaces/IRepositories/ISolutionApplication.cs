using SmartSolution.Application.Dtos;
using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface ISolutionApplication : IRepositoryApplication<SolutionDto>
    {
        Task<bool> SetProjectToSolutionAsync(IEnumerable<ProjectDto> projects, Int32 solution);
        Task<IEnumerable<SolutionDto>> GetByUserAsync(Int32 usuario);
        Task<IEnumerable<SolutionDto>> GetByUserEmailAsync(string email);
        Task<SolutionDto> GetSolutionByIdAsync(Int32 id);
        Task<bool> SetOneProjectToSolutionAsync(Int32 project, Int32 solution);
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(Int32 solution);
    }
}
