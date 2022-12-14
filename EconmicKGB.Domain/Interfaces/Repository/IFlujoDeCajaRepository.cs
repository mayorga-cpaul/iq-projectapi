using SmartSolution.Domain.Entities.EntitiesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IFlujoDeCajaRepository : IRepository<FlujoDeCaja>
    {
        Task<IEnumerable<FlujoDeCaja>> GetBySolutionID(int solutionID);
    }
}
