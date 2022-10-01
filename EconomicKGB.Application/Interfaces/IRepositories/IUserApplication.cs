using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IUserApplication : IRepositoryApplication<UserDto>
    {
        Task<UserDto> GetByNameAsync(string name);
        Task<UserDto> GetByEmailAsync(string email);
        Task<bool> AccessToAppAsync(string email, string name, string password);
        Task<bool> ExistEmailAsync(string email);
        Task<string> RecoveryPasswordAsync(string email);
        Task<IEnumerable<SolutionDto>> GetByUserAsync(Int32 id);
    }
}
