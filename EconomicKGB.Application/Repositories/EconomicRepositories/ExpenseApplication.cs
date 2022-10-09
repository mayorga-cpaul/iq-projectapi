using AutoMapper;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class ExpenseApplication : IExpenseApplication
    {
        private readonly IExpenseServices repository;
        private readonly IMapper mapper;

        public ExpenseApplication(IExpenseServices repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(ProjectExpenseDto entity)
        {
            var projectExpense = mapper.Map<ProjectExpense>(entity);
            return await repository.CreateAsync(projectExpense);
        }

        public async Task<int> DeleteAsync(int guid)
        {
            return await repository.DeleteAsync(guid);
        }

        public async Task<IEnumerable<ProjectExpenseDto>> GetAllAsync()
        {
            var projectExpense = await repository.GetAllAsync();
            var projectExpenseDto = mapper.Map<IEnumerable<ProjectExpenseDto>>(projectExpense);

            return projectExpenseDto;
        }

        public async Task<IEnumerable<ProjectExpenseDto>> GetAllExpenses(int projectId)
        {
            var projectExpense = await repository.GetAllExpensesAsync(projectId);
            var projectExpenseDto = mapper.Map<IEnumerable<ProjectExpenseDto>>(projectExpense);

            return projectExpenseDto;
        }

        public async Task<ProjectExpenseDto> GetAsync(int guid)
        {
            var projectExpense = await repository.GetAsync(guid);
            var projectExpenseDto = mapper.Map<ProjectExpenseDto>(projectExpense);
            return projectExpenseDto;
        }

        public async Task<bool> SetExpenseAsync(ProjectExpenseDto gastoProjects)
        {
            var projectExpenses = mapper.Map<ProjectExpense>(gastoProjects);
            return await repository.SetExpenseAsync(projectExpenses);
        }

        public async Task<bool> UpdateAsync(int id, ProjectExpenseDto entity)
        {
            var projectExpense = mapper.Map<ProjectExpense>(entity);
            projectExpense.Id = id;
            return await repository.UpdateAsync(projectExpense);
        }
    }
}
