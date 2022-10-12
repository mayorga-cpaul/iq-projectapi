using SmartSolution.Application.Dtos.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Application.Interfaces.IRepositories
{
    public interface IFlujoCajaApp : IRepositoryApplication<FlujoDeCajaDto>
    {
        Task<IEnumerable<FlujoDeCajaDto>> GetBySolutionID(int solutionID);
    }
}
