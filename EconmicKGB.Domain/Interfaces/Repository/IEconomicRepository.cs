using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IEconomicRepository : IRepository<Economic>
    {
        Task<IEnumerable<Economic>> FindByUserEmailAsync(string email);
        Task<int> CreateCashFlowAsync(List<Economic> economicClasses, int nper);
    }
}
