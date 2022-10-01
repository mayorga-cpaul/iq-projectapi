using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Domain.Services.Services.RepositoriesServices
{
    public class ConversionServices : BaseServices<Conversion>, IConversionServices
    {
        private readonly IConversionRepository _conversionRepository;
        public ConversionServices(IConversionRepository _conversionRepository)
            : base(_conversionRepository)
        {
            this._conversionRepository = _conversionRepository;
        }

        public async Task<IEnumerable<Conversion>> FindByUserEmailAsync(string email)
        {
            try
            {
                return await _conversionRepository.FindByUserEmailAsync(email);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
