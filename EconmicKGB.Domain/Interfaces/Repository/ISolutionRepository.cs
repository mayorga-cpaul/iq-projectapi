using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface ISolutionRepository : IRepository<Solution>
    {
        /// <summary>
        /// Set one solution to user
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        Task<bool> SetSolutionToUser(Solution solution);
        /// <summary>
        /// Get all the solutions by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Solution>> GetByUserAsync(Int32 userId);

        /// <summary>
        /// Get all the solutions by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<Solution>> GetByUserEmailAsync(string email);

        /// <summary>
        /// Get one solution by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Solution> GetSolutionByIdAsync(Int32 userId);

        /// <summary>
        /// Get the last Id Created of the db
        /// </summary>
        /// <returns></returns>
        Task<int> LastCreatedAsync();
    }
}
