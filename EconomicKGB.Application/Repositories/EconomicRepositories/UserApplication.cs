using AutoMapper;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserServices userServices;
        private readonly IMapper mapper;

        public UserApplication(IUserServices userServices, IMapper mapper)
        {
            this.userServices = userServices;
            this.mapper = mapper;
        }

        public async Task<bool> AccessToAppAsync(string email, string name, string password)
        {
            return await userServices.AccessToAppAsync(email, name, password);
        }

        public async Task<Int32> CreateAsync(UserDto entity)
        {
            var user = mapper.Map<User>(entity);
            return await userServices.CreateAsync(user);
        }

        public async Task<Int32> DeleteAsync(Int32 id)
        {
            return await userServices.DeleteAsync(id);
        }

        public async Task<bool> ExistEmailAsync(string email)
        {
            return await userServices.ExistEmailAsync(email);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await userServices.GetAllAsync();
            var usersDto = mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }

        public async Task<UserDto> GetAsync(Int32 id)
        {
            var user = await userServices.GetAsync(id);
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await userServices.GetByEmailAsync(email);
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> GetByNameAsync(string name)
        {
            var user = await userServices.GetByNameAsync(name);
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<IEnumerable<SolutionDto>> GetByUserAsync(Int32 id)
        {
            var solutions = await userServices.GetByUserAsync(id);
            var solutionsDto = mapper.Map<IEnumerable<SolutionDto>>(solutions);
            return solutionsDto;
        }

        public async Task<string> RecoveryPasswordAsync(string email)
        {
            return await userServices.RecoveryPasswordAsync(email);
        }

        public async Task<bool> UpdateAsync(int id, UserDto entity)
        {
            var user = mapper.Map<User>(entity);
            user.Id = id;
            return await userServices.UpdateAsync(user);
        }
    }
}
