using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Services.RepositoriesServices;
using SmartSolution.Services.Interface.IRepositoriesServices;

namespace SmartSolution.Services.Services.RepositoriesServices
{
    public class InvesmentAreaServices : BaseServices<InvesmentArea>, IInvesmentAreaServices
    {
        private readonly IInvestmentAreaRepository investmentAreaRepository;
        public InvesmentAreaServices(IInvestmentAreaRepository investmentAreaRepository) : base(investmentAreaRepository)
        {
            this.investmentAreaRepository = investmentAreaRepository;
        }

        public async Task<IEnumerable<InvesmentArea>> GetProjects(int projectId)
        {
            try
            {
                return await investmentAreaRepository.GetProjects(projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SetInvesmentArea(InvesmentArea inversionProyectos)
        {
            try
            {
                return await investmentAreaRepository.SetInvesmentArea(inversionProyectos);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
