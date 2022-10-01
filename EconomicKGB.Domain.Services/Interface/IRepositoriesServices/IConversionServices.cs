using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.Domain.Services.Interface.IRepositoriesServices
{
    public interface IConversionServices : IRepositoryServices<Conversion>
    {
        Task<IEnumerable<Conversion>> FindByUserEmailAsync(string email);
    }
}
