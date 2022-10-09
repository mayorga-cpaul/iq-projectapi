using AutoMapper;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
namespace SmartSolution.Application.Repositories.EconomicRepositories;

public class SolutionApplication : ISolutionApplication
{
    private readonly ISolutionServices solutionServices;
    private readonly IMapper mapper;

    public SolutionApplication(ISolutionServices solutionService, IMapper mapper)
    {
        this.solutionServices = solutionService;
        this.mapper = mapper;
    }

    public async Task<Int32> CreateAsync(SolutionDto entity)
    {
        var solution = mapper.Map<Solution>(entity);
        return await solutionServices.CreateAsync(solution);
    }

    public async Task<Int32> DeleteAsync(Int32 solutionId)
    {
        return await solutionServices.DeleteAsync(solutionId);
    }

    public async Task<IEnumerable<SolutionDto>> GetAllAsync()
    {
        var solutions = await solutionServices.GetAllAsync();
        var solutionsDto = mapper.Map<IEnumerable<SolutionDto>>(solutions);
        return solutionsDto;
    }

    public async Task<SolutionDto> GetAsync(Int32 solutionId)
    {
        var solution = await solutionServices.GetAsync(solutionId);
        var solutionDto = mapper.Map<SolutionDto>(solution);
        return solutionDto;
    }

    public async Task<IEnumerable<SolutionDto>> GetByUserAsync(Int32 userId)
    {
        var solution = await solutionServices.GetByUserAsync(userId);
        var solutionDto = mapper.Map<IEnumerable<SolutionDto>>(solution);
        return solutionDto;
    }

    public async Task<IEnumerable<SolutionDto>> GetByUserEmailAsync(string email)
    {
        var solution = await solutionServices.GetByUserEmailAsync(email);
        var solutionDto = mapper.Map<IEnumerable<SolutionDto>>(solution);
        return solutionDto;
    }

    public async Task<SolutionDto> GetSolutionByIdAsync(Int32 solutionId)
    {
        var solution = await solutionServices.GetAsync(solutionId);
        var solutionDto = mapper.Map<SolutionDto>(solution);
        return solutionDto;
    }

    public async Task<int> LastCreatedAsync()
    {
        return await solutionServices.LastCreatedAsync();
    }

    public async Task<bool> SetSolutionToUserAsync(SolutionDto solutionDto)
    {
        var solution = mapper.Map<Solution>(solutionDto);
        return await solutionServices.SetSolutionToUser(solution);
    }

    public async Task<bool> UpdateAsync(Int32 solutionId, SolutionDto entity)
    {
        var solution = mapper.Map<Solution>(entity);
        solution.Id = solutionId;
        return await solutionServices.UpdateAsync(solution);
    }
}
