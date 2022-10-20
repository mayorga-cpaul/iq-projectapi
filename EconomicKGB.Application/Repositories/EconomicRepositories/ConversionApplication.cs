using AutoMapper;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class ConversionApplication : IConversionApplication
    {
        private readonly IConversionServices conversionServices;
        private readonly IMapper mapper;

        public ConversionApplication(IConversionServices conversionServices, IMapper mapper)
        {
            this.conversionServices = conversionServices;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(ConversionDto entity)
        {
            try
            {
                var conversion = mapper.Map<Conversion>(entity);
                return await conversionServices.CreateAsync(conversion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Int32> DeleteAsync(Int32 id)
        {
            try
            {
                return await conversionServices.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ConversionDto>> FindByUserEmailAsync(string email)
        {
            try
            {
                var conversions = await conversionServices.FindByUserEmailAsync(email);
                var conversionsDto = mapper.Map<IEnumerable<ConversionDto>>(conversions);
                return conversionsDto;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<ConversionDto>> GetAllAsync()
        {
            try
            {
                var conversion = await conversionServices.GetAllAsync();
                var conversionDto = mapper.Map<IEnumerable<ConversionDto>>(conversion);
                return conversionDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ConversionDto> GetAsync(Int32 guid)
        {
            try
            {
                var conversion = await conversionServices.GetAsync(guid);
                var conversionDto = mapper.Map<ConversionDto>(conversion);
                return conversionDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, ConversionDto entity)
        {
            try
            {
                var conversion = mapper.Map<Conversion>(entity);
                //conversion.Id = id;
                return await conversionServices.UpdateAsync(conversion);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
