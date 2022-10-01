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

        public async Task<Boolean> AccessToAppAsync(string email, string name, string password)
        {
            try
            {
                return await userRepository.AccessToAppAsync(email, name, password);
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

        public async Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario)
        {
            try
            {
                return await userRepository.GetByUserAsync(usuario);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<string> RecoveryPasswordAsync(string email)
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
    }
}
