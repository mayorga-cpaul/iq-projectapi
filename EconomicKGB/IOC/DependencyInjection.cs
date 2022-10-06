using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Application.Repositories.EconomicRepositories;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Infraestructure.Data.Repositories;
using SmartSolution.Services.Interface.IRepositoriesServices;
using SmartSolution.Services.Services.RepositoriesServices;

namespace SmartSolution.API.IOC
{
    public static class DependencyInjection
    {
        public static void IOCEconomic(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IConversionApplication, ConversionApplication>();
            builder.Services.AddScoped<IEconomicApplication, EconomicApplication>();
            builder.Services.AddScoped<IProjectApplication, ProjectApplication>();
            builder.Services.AddScoped<ISolutionApplication, SolutionApplication>();
            builder.Services.AddScoped<IUserApplication, UserApplication>();
            builder.Services.AddScoped<ICostApplication, CostApplication>();
            builder.Services.AddScoped<IExpenseApplication, ExpenseApplication>();
            builder.Services.AddScoped<IInvesmentAreaApplication, InvesmentAreaApplication>();
            builder.Services.AddScoped<IInvesmentEntityApplication, InvesmentEntityApplication>();
            builder.Services.AddScoped<IEntryApplication, EntryApplication>();

            builder.Services.AddScoped<IConversionServices, ConversionServices>();
            builder.Services.AddScoped<IEconomicServices, EconomicServices>();
            builder.Services.AddScoped<IProjectServices, ProjectServices>();
            builder.Services.AddScoped<ISolutionServices, SolutionServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<ICostServices, CostServices>();
            builder.Services.AddScoped<IExpenseServices, ExpenseServices>();
            builder.Services.AddScoped<IInvesmentAreaServices, InvesmentAreaServices>();
            builder.Services.AddScoped<IInvesmentEntityServices, InvesmentEntityServices>();
            builder.Services.AddScoped<IEntryService, EntryService>();

            builder.Services.AddScoped<IConversionRepository, ConversionRepository>();
            builder.Services.AddScoped<IEconomicRepository, EconomicRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<ISolutionRepository, SolutionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICostRepository, CostRepository>();
            builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
            builder.Services.AddScoped<IInvestmentAreaRepository, InvestmentAreaRepository>();
            builder.Services.AddScoped<IInvesmentEntityRepository, InvesmentEntityRepository>();
            builder.Services.AddScoped<IEntryRepository, EntryRepository>();
        }
    }
}
