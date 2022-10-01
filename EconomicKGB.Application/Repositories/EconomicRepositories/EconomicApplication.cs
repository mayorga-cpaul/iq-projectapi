using AutoMapper;
using SmartSolution.Application.Dtos.Economic;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using SmartSolution.Domain.Entities.Economics;

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

        public async Task<int> CreateCashFlowAsync(List<EconomicDto> economicClasses, int nper)
        {
            var economics = mapper.Map<List<Economic>>(economicClasses);
            return await economicRepository.CreateCashFlowsAsync(economics, nper);
        }

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

        public async Task<IEnumerable<AnnuityDto>> GetAnnuitiesAsync(Int32 userId)
        {
            var annuaties = await economicRepository.Find(e => e.SolutionId == userId);
            var annuatiesDto = mapper.Map<IEnumerable<AnnuityDto>>(annuaties);

            return annuatiesDto;    
        }

        public async Task<EconomicDto> GetAsync(int id)
        {
            var economic = await economicRepository.GetAsync(id);
            var economicDto = mapper.Map<EconomicDto>(economic);
            return economicDto;
        }

        public async Task<IEnumerable<RateDto>> GetInterestAsync(Int32 userId)
        {
            var interest = await economicRepository.Find(e => e.SolutionId == userId);
            var interestDto = mapper.Map<IEnumerable<RateDto>>(interest);

            return interestDto;
        }

        public async Task<IEnumerable<EconomicDto>> GetPureEconomicsAsync(Int32 userId)
        {
            // TODO: Bad Implementation
            var economic = await economicRepository.Find(e => e.SolutionId == userId);
            var economicDto = mapper.Map<IEnumerable<EconomicDto>>(economic);

            return economicDto;
        }

        public async Task<bool> UpdateAsync(int id, EconomicDto entity)
        {
            var economic = mapper.Map<Economic>(entity);
            economic.Id = id;
            return await economicRepository.UpdateAsync(economic);
        }
    }
}
