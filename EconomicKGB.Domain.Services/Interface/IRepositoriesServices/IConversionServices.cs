using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Services.Interface.IRepositoriesServices
{
    public interface IConversionServices : IRepositoryServices<Conversion>
    {
        /// <summary>
        /// GEt all the conversions by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<Conversion>> FindByUserEmailAsync(string email);
    }
}
