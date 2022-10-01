using SmartSolution.Domain.Entities.Economics;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Services.Interface.IRepositoriesServices
{
    public interface IEconomicServices : IRepositoryServices<Economic>
    {
        Task<IEnumerable<Economic>> FindByUserEmailAsync(string email);
        Task<Int32> CreateCashFlowsAsync(List<Economic> economicClasses, Int32 nper);
    }
}
