using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class SolutionRepository : BaseRepository<Solution>, ISolutionRepository
    {
        private readonly EconomicKGBContext repository;
        public SolutionRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Solution>> GetByUserAsync(Int32 userId)
        {
            try
            {
                if (!await repository.Usuarios.AnyAsync(e => e.Id == userId))
                    throw new Exception("El usuario no existe");

                return await Task.FromResult(repository.Solutions.Where(e => e.UserId == userId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Solution>> GetByUserEmailAsync(string email)
        {
            try
            {
                if (email is null)
                {
                    throw new ArgumentNullException("El email no puede ser null");
                }
                var user = await repository.Usuarios.
                    Where(u => u.Email == email).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new ArgumentException("No existe un usuario con este email");
                }

                return await Task.FromResult(repository.Solutions.Where(s => s.UserId == user.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Solution> GetSolutionByIdAsync(Int32 id)
        {
            try
            {
                if (id < 0)
                {
                    throw new Exception("Ingrese un id mayor a cero");
                }

                Solution? solution = await repository.Solutions.FirstOrDefaultAsync(e => e.Id == id);

                if (solution is null)
                    throw new Exception("La solución no existe");
                else
                    return solution;    

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> LastCreatedAsync()
        {
            try
            {
                return await repository.Solutions.MaxAsync(e => e.Id);
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public async Task<bool> SetSolutionToUser(Solution solution)
        {
            try
            {
                _ = (repository.Usuarios.Any(e => e.Id == solution.UserId) is false)
                ? throw new Exception("El proyecto que desea asignarle al costo no existe")
                : repository.Solutions.Add(solution); await repository.SaveChangesAsync(); return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
