using SmartSolution.Application.Dtos;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface ISolutionApplication : IRepositoryApplication<SolutionDto>
    {
        /// <summary>
        /// Set one solution to user
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        Task<bool> SetSolutionToUserAsync(SolutionDto solution);

        /// <summary>
        /// Get all the solutions by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<SolutionDto>> GetByUserAsync(Int32 userId);

        /// <summary>
        /// Get all the solutions by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<SolutionDto>> GetByUserEmailAsync(string email);

        /// <summary>
        /// Get one solution by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SolutionDto> GetSolutionByIdAsync(Int32 userId);

        /// <summary>
        /// Get the last Id Created of the db
        /// </summary>
        /// <returns></returns>
        Task<int> LastCreatedAsync();
    }
}
