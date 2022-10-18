using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [Route("api/flujoCaja")]
    [ApiController]
    public class FlujoCajaController : ControllerBase
    {
        private readonly IFlujoCajaApp flujoCajaApplication;

        public FlujoCajaController(IFlujoCajaApp flujoCajaApplication)
        {
            this.flujoCajaApplication = flujoCajaApplication;
        }
        #region CRUD   
        [HttpPost]
        public async Task<ActionResult> CreateAsync(FlujoDeCajaDto flujoDeCaja)
        {
            try
            {
                return Ok(await flujoCajaApplication.CreateAsync(flujoDeCaja));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPatch("{id}")]
        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(Int32 id, FlujoDeCajaDto flujoDeCaja)
        {
            try
            {
                return Ok(await flujoCajaApplication.UpdateAsync(id, flujoDeCaja));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idflujo}")]
        public async Task<ActionResult> GetByIdAsync(Int32 id)
        {
            try
            {
                var flujo = (await flujoCajaApplication.GetAsync(id));

                return Ok(flujo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Int32 id)
        {
            try
            {
                var existingItem = await flujoCajaApplication.GetAsync(id);

                if (existingItem is null)
                {
                    return NotFound();
                }

                int result = await flujoCajaApplication.DeleteAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<FlujoDeCajaDto>> GetAllAsync()
        {
            try
            {
                var flujosDto = (await flujoCajaApplication.GetAllAsync());

                return Ok(flujosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region otherMethods
        [HttpGet]
        [Route("getbysolutionid")]
        public async Task<ActionResult<FlujoDeCajaDto>> GetBySolutionId(Int32 solutionId)
        {
            try
            {
                var flujos = (await flujoCajaApplication.GetBySolutionID(solutionId));

                return Ok(flujos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
