using SmartSolution.Application.Dtos;
using SmartSolution.Application.Dtos.Economic;
using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IEconomicApplication : IRepositoryApplication<EconomicDto>
    {
        Task<IEnumerable<EconomicDto>> FindByUserEmailAsync(string email);
        Task<IEnumerable<RateDto>> GetInterestAsync(Int32 email);
        Task<IEnumerable<AnnuityDto>> GetAnnuitiesAsync(Int32 email);
        Task<IEnumerable<EconomicDto>> GetEconomicsBySolutionAsync(Int32 solution);
        //Task<int> CreateCashFlowAsync(List<EconomicDto> economicClasses, int nper);
    }
}
