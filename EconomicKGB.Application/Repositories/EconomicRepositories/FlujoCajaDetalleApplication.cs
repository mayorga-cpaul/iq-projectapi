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
    public class FlujoCajaDetalleApplication : IFlujoCajaDetalleApp
    {
        private readonly IFlujoCajaDetalleServices flujocajaDet;
        private readonly IMapper mapper;

        public FlujoCajaDetalleApplication(IFlujoCajaDetalleServices flujocajaDet, IMapper mapper)
        {
            this.flujocajaDet = flujocajaDet;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(FlujoDeCajaDetalleDto entity)
        {
            try
            {
                var flujo = mapper.Map<FlujoDeCajaDetalle>(entity);
                return await flujocajaDet.CreateAsync(flujo);
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
                return await flujocajaDet.DeleteAsync(guid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<FlujoDeCajaDetalleDto>> GetAllAsync()
        {
            try
            {
                var flujo = await flujocajaDet.GetAllAsync();
                var flujocaja = mapper.Map<IEnumerable<FlujoDeCajaDetalleDto>>(flujo);
                return flujocaja;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //TODO: Esto no va a funcionar aqui 
        public async Task<FlujoDeCajaDetalleDto> GetAsync(int guid)
        {
            try
            {
                var flujo = await flujocajaDet.GetAsync(guid);
                var flujoDto = mapper.Map<FlujoDeCajaDetalleDto>(flujo);
                return flujoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<FlujoDeCajaDetalleDto>> GetByFlujoId(int flujoId)
        {
            var flujo = await flujocajaDet.GetByFlujoId(flujoId);
            var flujoDto = mapper.Map<IEnumerable<FlujoDeCajaDetalleDto>>(flujo);
            return flujoDto;
        }

        public async Task<IEnumerable<EconomicDto>> GetEconomics(int flujoDetalle)
        {
            var economic = await flujocajaDet.GetEconomics(flujoDetalle);
            var economicDto = mapper.Map<IEnumerable<EconomicDto>>(economic);
            return economicDto;
        }

        public async Task<bool> UpdateAsync(int id, FlujoDeCajaDetalleDto entity)
        {
            try
            {
                var flujo = mapper.Map<FlujoDeCajaDetalle>(entity);
                //flujo.Id = id;
                return await flujocajaDet.UpdateAsync(flujo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
