using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class ConversionRepository : BaseRepository<Conversion>, IConversionRepository
    {
        private readonly EconomicKGBContext repository;
        public ConversionRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Conversion>> FindByUserEmailAsync(string email)
        {
            try
            {
                if (email is null)
                {
                    throw new ArgumentNullException("El email no puede ser null");
                }
                var user = await repository.Users.
                    Where(u => u.Email == email).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new ArgumentException("No existe un usuario con este email");
                }

                return await Task.FromResult(repository.Conversions.Where(c => c.UserId == user.Id));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
