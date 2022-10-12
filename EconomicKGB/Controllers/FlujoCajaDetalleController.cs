using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSolution.API.Controllers
{
    [Route("api/flujoCajaDetalle")]
    [ApiController]
    public class FlujoCajaDetalleController : ControllerBase
    {
        private readonly IFlujoCajaDetalleApp repository;

        public FlujoCajaDetalleController(IFlujoCajaDetalleApp flujoCajaDetalleApp)
        {
            this.repository = flujoCajaDetalleApp;
        }
        #region CRUD 
        [HttpPost]
        public async Task<ActionResult> CreateAsync(FlujoDeCajaDetalleDto flujo)
        {
            try
            {
                return Ok(await repository.CreateAsync(flujo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(Int32 id, FlujoDeCajaDetalleDto flujo)
        {
            try
            {
                return Ok(await repository.UpdateAsync(id, flujo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(Int32 id)
        {
            try
            {
                var solutionDto = (await repository.GetAsync(id));

                return Ok(solutionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(Int32 id)
        {
            try
            {
                var existingItem = await repository.GetAsync(id);

                if (existingItem is null)
                {
                    return NotFound();
                }

                int result = await repository.DeleteAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<FlujoDeCajaDetalleDto>> GetAllAsync()
        {
            try
            {
                var solutionDtos = (await repository.GetAllAsync());

                return Ok(solutionDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region other methods
        [HttpGet]
        [Route("getbyflujoid")]
        public async Task<ActionResult<FlujoDeCajaDetalleDto>> GetByFlujoId(int flujoId)
        {
            try
            {
                var flujos = (await repository.GetByFlujoId(flujoId));

                return Ok(flujos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getEconomicsbyflujo")]
        public async Task<ActionResult<EconomicDto>> GetEconomics(int id)
        {
            try
            {
                var economic = (await repository.GetEconomics(id));

                return Ok(economic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
