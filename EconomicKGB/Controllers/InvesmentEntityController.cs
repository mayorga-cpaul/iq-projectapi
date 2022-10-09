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

        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(int id, InvestmentEntityDto projectCostDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                return Ok(await repository.UpdateAsync(id, projectCostDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
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
        public async Task<ActionResult> SetInvesmentAsync(InvestmentEntityDto entidadInvs)
        {
            try
            {
                return Ok(await repository.SetInvesmentEntityAsync(entidadInvs));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<InvestmentEntityDto>> GetInvesmentAsync(int solutionId)
        {
            try
            {
                return Ok(await repository.GetInvesmentAsync(solutionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByIdAsync")]
        public async Task<ActionResult> GetInvesment(int id)
        {
            try
            {
                return Ok(await repository.GetInvesmentAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getInvesmentBySolutionId")]
        public async Task<ActionResult<InvestmentEntityDto>> GetInvesmentEntities(int projectId)
        {
            try
            {
                return Ok(await repository.GetInvesmentEntities(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
