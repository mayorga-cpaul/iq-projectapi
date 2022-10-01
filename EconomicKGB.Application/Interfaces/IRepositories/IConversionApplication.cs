using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IConversionApplication : IRepositoryApplication<ConversionDto>
    {
        Task<IEnumerable<ConversionDto>> FindByUserEmailAsync(string email);
    }
}
