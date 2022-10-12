using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.Economics;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class EconomicRepository : BaseRepository<Economic>, IEconomicRepository
    {
        private readonly EconomicKGBContext repository;

        public EconomicRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Economic>> FindByUserEmailAsync(string email)
        {
            //TODO: mala implementacion de metodo de econtrar economic por usuario 
            try
            {
                if (email is null)
                {
                    throw new ArgumentNullException("El email no puede ser null");
                }
                var user = await repository.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new ArgumentException("No existe un usuario con este email");
                }

                // TODO: This method has a bad implementation i don't want to do this 
                return await Task.FromResult(repository.EconomicClasses.Where(e => e.SolutionId == user.Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<int> CreateCashFlowAsync(List<Economic> economicClasses, int nper)
        //{
        //    try
        //    {
        //        decimal vp;
        //        var series = (from e in economicClasses where e is Serie select (Serie)e);
        //        //series = series.Where(s => s.PeriodoGracia > 0).ToList();
        //        //foreach (var s in series)
        //        //{
        //        //    vp += s.ValorPresente * Math.Round((1+s.TasaInteres), -s.PeriodoGracia);
        //        //}
        //        vp = series.Sum(s => s.PresentValue * Math.Round((1 + s.TasaInteres), -s.PeriodoGracia));
        //        //var anualidades = (from e in economicClasses where e is Anualidad && !e.GetType().IsSubclassOf(typeof(Anualidad)) select (Anualidad)e).ToList();
        //        //vp += anualidades.Sum(a=>a.ValorPresente);
        //        //var intereses = (from e in economicClasses where e is Interes select (Interes)e).ToList();
        //        //vp += intereses.Sum(i=>i.ValorPresente);
        //        var seriesAnualidades = Task.FromResult(economicClasses.Where(e => e is Interest ||
        //        (e is Annuaty && !e.GetType().IsSubclassOf(typeof(Annuaty)))));

        //        vp += seriesAnualidades.Result.Sum(s => s.PresentValue);

        //        var temp = economicClasses;

        //        Economic cashflow = new Economic()
        //        {
        //            SolutionId = temp[0].SolutionId,
        //            TasaInteres = temp[0].TasaInteres,
        //            //ValorPresente = economicClasses.Sum(u => u.ValorPresente),
        //            PresentValue = vp,
        //            NumPeriodos = nper,
        //            FutureValue = vp * Math.Round((1 + temp[0].TasaInteres), nper),
        //        };
        //        await CreateAsync(cashflow);
        //        return 1;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<IEnumerable<Economic>> GetEconomicBySolutionAsync(int solutionId)
        {
            try
            {
                return await Task.FromResult(repository.EconomicClasses.Where(e => e.SolutionId == solutionId));
            }
            catch (Exception)
            {
                throw;
            }
        }
        //TODO: Le cambie el tipo de retorno de annuaty a economic
        public async Task<IEnumerable<Economic>> GetAnualidadesAsync(int solutionId)
        {
            //TODO: Ver si este metodo de obtener annuaty esta bien implementado
            try
            {
                return await Task.FromResult(repository.EconomicClasses
                    .Where(e => e.SolutionId == solutionId
                    //&& (string.Compare(e.Discriminator, "Anualidad", StringComparison.CurrentCultureIgnoreCase) == 0)));
                    && (e.Discriminator.Equals("Anualidad"))));
            }
            catch (Exception)
            {
                throw;
            }
        }
        //TODO: le cambie el tipo de retorno de interes a economic
        public async Task<IEnumerable<Economic>> GetInteresAsync(int solutionId)
        {
            //TODO: ver si este metodo de obtener interes esta bien implementado
            try
            {
                return await Task.FromResult(repository.EconomicClasses
                    .Where(e => e.SolutionId == solutionId
                    //&& (string.Compare(e.Discriminator, "Interes", StringComparison.CurrentCultureIgnoreCase) == 0)));
                    && (e.Discriminator.Equals("Interes"))));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
