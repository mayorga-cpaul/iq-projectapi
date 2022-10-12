using AutoMapper;
using SmartSolution.Application.Dtos.Economic;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using SmartSolution.Domain.Entities.Economics;
using SmartSolution.Domain.Enums.Types;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class EconomicApplication : IEconomicApplication
    {
        private readonly IEconomicServices economicRepository;
        private readonly IMapper mapper;

        public EconomicApplication(IEconomicServices economicRepository, IMapper mapper)
        {
            this.economicRepository = economicRepository;
            this.mapper = mapper;
        }

        public async Task<Int32> CreateAsync(EconomicDto entity)
        {
            var economic = mapper.Map<Economic>(entity);
            return await economicRepository.CreateAsync(economic);
        }

        //public async Task<int> CreateCashFlowAsync(List<EconomicDto> economicClasses, int nper)
        //{
        //    var economics = mapper.Map<List<Economic>>(economicClasses);
        //    return await economicRepository.CreateCashFlowsAsync(economics, nper);
        //}

        public async Task<Int32> DeleteAsync(int guid)
        {
            return await economicRepository.DeleteAsync(guid);
        }

        public async Task<IEnumerable<EconomicDto>> FindByUserEmailAsync(string email)
        {
            var economic = await economicRepository.FindByUserEmailAsync(email);
            var economicDto = mapper.Map<IEnumerable<EconomicDto>>(economic);
            return economicDto;
        }

        public async Task<IEnumerable<EconomicDto>> GetAllAsync()
        {
            var economics = await economicRepository.GetAllAsync();
            var economicsDto = mapper.Map<IEnumerable<EconomicDto>>(economics);
            return economicsDto;
        }

        public async Task<IEnumerable<AnnuityDto>> GetAnnuitiesAsync(Int32 solutionId)
        {
            //TODO: componer get anualidades de economic application
            //var annuaties = await economicRepository.Find(e => e.SolutionId == solutionId);
            //var annuatiesDto = mapper.Map<IEnumerable<AnnuityDto>>(annuaties);

            //return annuatiesDto;    
            var economics = await economicRepository.GetAnualidadesAsync(solutionId);
            //var anualidadesDto = mapper.Map<IEnumerable<AnnuityDto>>(economics);
            var anualidadesDto = economics.Select(e => new AnnuityDto()
            {
                Id = e.Id,
                IdSolution = e.SolutionId,
                FutureValue = e.FutureValue,
                PresentValue = e.PresentValue,
                TasaInteres = e.TasaInteres,
                NumPeriodos = e.NumPeriodos,
                PagoAnual = (decimal)e.PagoAnual,
                PeriodoGracia = e.PeriodoGracia,
                Crecimiento = (decimal)e.Crecimiento,
                FuturoGradiente = (decimal)e.FuturoGradiente,
                TipoAnualidad = (TipoAnualidad)e.TipoAnualidad,
                Periodo = (Periodo) e.Periodo,
                TipoDeCrecimiento = (TipoCrecimiento)e.TipoDeCrecimiento
            });

            return anualidadesDto;
        }

        public async Task<EconomicDto> GetAsync(int id)
        {
            var economic = await economicRepository.GetAsync(id);
            var economicDto = mapper.Map<EconomicDto>(economic);
            return economicDto;
        }

        public async Task<IEnumerable<RateDto>> GetInterestAsync(Int32 solutionId)
        {
            //TODO: componer get intereses de economic application
            //var interest = await economicRepository.Find(e => e.SolutionId == solutionId);
            //var interestDto = mapper.Map<IEnumerable<RateDto>>(interest);

            //return interestDto;

            var economics = await economicRepository.GetInteresAsync(solutionId);
            //var rateDto = mapper.Map<IEnumerable<RateDto>>(economics);
            var rateDto = economics.Select(e => new RateDto()
            {
                Id = e.Id,
                IdSolution = e.SolutionId,
                FutureValue = e.FutureValue,
                PresentValue = e.PresentValue,
                TasaInteres = e.TasaInteres,
                NumPeriodos = e.NumPeriodos,
                TipoInteres = (TipoInteres)e.TipoInteres,
                FrecuenciaTasa = (FrecuenciaTasa)e.FrecuenciaTasa,
            });
            return rateDto;
        }

        public async Task<IEnumerable<EconomicDto>> GetEconomicsBySolutionAsync(Int32 solutionID)
        {
            // TODO: Bad Implementation
            //var economic = await economicRepository.Find(e => e.SolutionId == solutionID);
            //var economicDto = mapper.Map<IEnumerable<EconomicDto>>(economic);

            //return economicDto;

            var economics = await economicRepository.GetEconomicBySolutionAsync(solutionID);
            var economcisDto = mapper.Map<IEnumerable<EconomicDto>>(economics);
            return economcisDto;
        }

        public async Task<bool> UpdateAsync(int id, EconomicDto entity)
        {
            var economic = mapper.Map<Economic>(entity);
            economic.Id = id;
            return await economicRepository.UpdateAsync(economic);
        }
    }
}
