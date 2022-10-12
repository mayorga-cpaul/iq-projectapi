using SmartSolution.Domain.Entities.Economics;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IEconomicRepository : IRepository<Economic>
    {
        Task<IEnumerable<Economic>> FindByUserEmailAsync(string email);
        //TODO: Quite creacion de cash flow 
        //Task<int> CreateCashFlowAsync(List<Economic> economicClasses, int nper);
        Task<IEnumerable<Economic>> GetEconomicBySolutionAsync(Int32 solutionId);
        //TODO: Ver si retornar anuaty o economic
        Task<IEnumerable<Economic>> GetAnualidadesAsync(Int32 solutionId);
        //TODO: ver si retornar interest o economic
        Task<IEnumerable<Economic>> GetInteresAsync(Int32 solutionId);
    }
}
