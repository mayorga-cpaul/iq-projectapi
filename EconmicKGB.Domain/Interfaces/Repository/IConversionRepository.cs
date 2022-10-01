using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IConversionRepository : IRepository<Conversion>
    {
        Task<IEnumerable<Conversion>> FindByUserEmailAsync(string email);
    }
}
