using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/invesmentEntity")]
    public class InvesmentEntityController : ControllerBase
    {
        private readonly IInvesmentEntityApplication repository;
        public InvesmentEntityController(IInvesmentEntityApplication repository)
        {
            this.repository = repository;
        }

        [HttpPatch("{Id}, {invesmentEntityDto}")]
        public async Task<ActionResult> UpdateAsync(Int32 Id, InvestmentEntityDto projectCostDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(Id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                return Ok(await repository.UpdateAsync(Id, projectCostDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteAsync(Int32 id)
        {
            try
            {
                var existingItem = await repository.GetAsync(id);

                if (existingItem is null)
                {
                    return NotFound();
                }

                return Ok(await repository.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
;
        }

        [HttpPost]
        public async Task<ActionResult> SetInvesmentAsync(IEnumerable<InvestmentEntityDto> entidadInvs, Int32 projectId)
        {
            try
            {
                return Ok(await repository.SetInvesmentEntity(entidadInvs, projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<InvestmentEntityDto>> GetInvesmentAsync(Int32 solutionId)
        {
            try
            {
                return Ok(await repository.GetInvesmentEntities(solutionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getInvesmentEntities")]
        public async Task<ActionResult> GetInvesment(Int32 projectId)
        {
            try
            {
                return Ok(await repository.GetInvesmentAsync(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
