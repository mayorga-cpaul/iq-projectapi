﻿using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Services.Interface.IRepositoriesServices
{
    public interface IUserServices : IRepositoryServices<User>
    {
        Task<User> GetByNameAsync(string name);
        Task<User> GetByEmailAsync(string email);
        Task<bool> AccessToAppAsync(string email, string name, string password);
        Task<bool> ExistEmailAsync(string email);
        Task<string> RecoveryPasswordAsync(string email);
        Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario);
    }
}
