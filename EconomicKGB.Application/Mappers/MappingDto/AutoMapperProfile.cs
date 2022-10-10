using AutoMapper;
using SmartSolution.Application.Dtos.Economic;
using SmartSolution.Domain.Entities.Economics;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Application.Dtos.EntitiesDto;

namespace SmartSolution.Application.Mappers.MappingDto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnnuityDto, Annuaty>();
            CreateMap<InvesmentAreaDto, InvesmentArea>();
            CreateMap<ConversionDto, Conversion>();
            CreateMap<ProjectCostDto, ProjectCost>();
            CreateMap<EconomicDto, Economic>();
            CreateMap<InvestmentEntityDto, InvestmentEntity>();
            CreateMap<ProjectExpenseDto, ProjectExpense>();
            CreateMap<ProjectEntryDto, ProjectEntry>();
            CreateMap<RateDto, Interest>();
            CreateMap<ProjectDto, Project>();
            CreateMap<SerieDto, Serie>();
            CreateMap<SolutionDto, Solution>();
            CreateMap<UserDto, User>();
            CreateMap<Economic, RateDto>();
            CreateMap<RateDto, Interest>();
            CreateMap<AssetDto, Asset>();

            CreateMap<Annuaty, AnnuityDto>();
            CreateMap<Asset, AssetDto>();
            CreateMap<InvesmentArea, InvesmentAreaDto>();
            CreateMap<Conversion, ConversionDto>();
            CreateMap<ProjectCost, ProjectCostDto>();
            CreateMap<Economic, EconomicDto>();
            CreateMap<InvestmentEntity, InvestmentEntityDto>();
            CreateMap<ProjectExpense, ProjectExpenseDto>();
            CreateMap<ProjectEntry, ProjectEntryDto>();
            CreateMap<Interest, RateDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<Serie, SerieDto>();
            CreateMap<Solution, SolutionDto>();
            CreateMap<User, UserDto>();
            CreateMap<RateDto, Economic>();
            CreateMap<Interest, RateDto>();
        }
    }
}
