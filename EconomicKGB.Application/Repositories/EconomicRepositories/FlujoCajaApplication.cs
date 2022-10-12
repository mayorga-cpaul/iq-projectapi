using AutoMapper;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Services.Interface.IRepositoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Application.Repositories.EconomicRepositories
{
    public class FlujoCajaApplication : IFlujoCajaApp
    {
        private readonly IFlujoCajaServices flujoCajaServices;
        private readonly IMapper mapper;

        public FlujoCajaApplication(IFlujoCajaServices flujoCajaServices, IMapper mapper)
        {
            this.flujoCajaServices = flujoCajaServices;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(FlujoDeCajaDto entity)
        {
            try
            {
                var flujo = mapper.Map<FlujoDeCaja>(entity);
                return await flujoCajaServices.CreateAsync(flujo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteAsync(int guid)
        {
            try
            {
                return await flujoCajaServices.DeleteAsync(guid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<FlujoDeCajaDto>> GetAllAsync()
        {
            try
            {
                var flujo = await flujoCajaServices.GetAllAsync();
                var flujocaja = mapper.Map<IEnumerable<FlujoDeCajaDto>>(flujo);
                return flujocaja;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FlujoDeCajaDto> GetAsync(int guid)
        {
            try
            {
                var flujo = await flujoCajaServices.GetAsync(guid);
                var flujoDto = mapper.Map<FlujoDeCajaDto>(flujo);
                return flujoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<FlujoDeCajaDto>> GetBySolutionID(int solutionID)
        {
            var flujo = await flujoCajaServices.GetBySolutionID(solutionID);
            var flujoDto = mapper.Map<IEnumerable<FlujoDeCajaDto>>(flujo);
            return flujoDto;
        }

        public async Task<bool> UpdateAsync(int id, FlujoDeCajaDto entity)
        {
            try
            {
                var flujo = mapper.Map<FlujoDeCaja>(entity);
                //flujo.Id = id;
                return await flujoCajaServices.UpdateAsync(flujo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
