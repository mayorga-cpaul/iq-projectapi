using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Services.Interface.IRepositoriesServices
{
    public interface IFlujoCajaServices : IRepositoryServices<FlujoDeCaja>
    {
        Task<IEnumerable<FlujoDeCaja>> GetBySolutionID(int solutionID);
    }
}
