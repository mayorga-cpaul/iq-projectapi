using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IUserApplication : IRepositoryApplication<UserDto>
    {
        /// <summary>
        /// Get one user by your name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<UserDto> GetByNameAsync(string name);

        /// <summary>
        /// Get one user by your email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserDto> GetByEmailAsync(string email);

        /// <summary>
        /// Access to app
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> AccessToAppAsync(string email, string password);

        /// <summary>
        /// If exist the email in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> ExistEmailAsync(string email);

        /// <summary>
        /// If you forgot the password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Recovery> RecoveryPasswordAsync(string email);
        /// <summary>
        /// Update the user with sp
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsyncWithSp(UserDto entity, int userId);


    }
}
