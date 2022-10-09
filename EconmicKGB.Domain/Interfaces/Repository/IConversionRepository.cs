using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IConversionRepository : IRepository<Conversion>
    {
        /// <summary>
        /// GEt all the conversions by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<Conversion>> FindByUserEmailAsync(string email);
    }
}
