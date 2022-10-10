using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Domain.Services.Services.RepositoriesServices
{
    public class UserServices : BaseServices<User>, IUserServices
    {
        private readonly IUserRepository userRepository;
        public UserServices(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Boolean> AccessToAppAsync(string email, string password)
        {
            try
            {
                return await userRepository.AccessToAppAsync(email, password);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Boolean> ExistEmailAsync(string email)
        {
            try
            {
                return await userRepository.ExistEmailAsync(email);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                return await userRepository.GetByEmailAsync(email);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<User> GetByNameAsync(string name)
        {
            try
            {
                return await userRepository.GetByNameAsync(name);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Recovery> RecoveryPasswordAsync(string email)
        {
            try
            {
                return await userRepository.RecoveryPasswordAsync(email);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateAsyncWithSp(User entity)
        {
            return await userRepository.UpdateAsyncWithSp(entity);
        }
    }
}
