using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IConversionApplication : IRepositoryApplication<ConversionDto>
    {
        /// <summary>
        /// GEt all the conversions by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<ConversionDto>> FindByUserEmailAsync(string email);
    }
}
