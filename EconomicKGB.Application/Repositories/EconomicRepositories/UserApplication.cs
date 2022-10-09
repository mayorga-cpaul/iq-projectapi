using AutoMapper;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using System.Drawing.Imaging;
using EasyBase64ToImage;
using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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

        public async Task<bool> AccessToAppAsync(string email, string password)
        {
            return await userServices.AccessToAppAsync(email, password);
        }

        public async Task<Int32> CreateAsync(UserDto entity)
        {
            User user = new User()
            {
                Name = entity.Name,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Dni = entity.Dni,
                Password = Encoding.ASCII.GetBytes(entity.Password),
                Creation = entity.Creation,
                State = entity.State,
            };

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

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Image stringToImage(string inputString)
        {
            byte[] imageBytes = Convert.FromBase64String(inputString);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public async Task<bool> UpdateAsyncWithSp(UserDto entity, int userId)
        {
            User user = new User()
            {
                Id = userId,
                Name = entity.Name,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Dni = entity.Dni,
                Password = Encoding.ASCII.GetBytes(entity.Password),
                Creation = entity.Creation,
                State = entity.State,
            };

            return await userServices.UpdateAsyncWithSp(user);
        }
    }
}
