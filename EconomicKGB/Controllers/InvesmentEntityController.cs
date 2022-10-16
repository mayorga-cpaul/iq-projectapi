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
        public async Task<ActionResult> UpdateAsync(int id, InvestmentEntityDto invesmentEntityDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                return Ok(await repository.UpdateAsync(id, invesmentEntityDto));
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
        public async Task<ActionResult> SetInvesmentAsync(InvestmentEntityDto invesmentEntity)
        {
            try
            {
                return Ok(await repository.SetInvesmentEntityAsync(invesmentEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<InvestmentEntityDto>> GetBySolutionIdAsync(int solutionId)
        {
            try
            {
                return Ok(await repository.GetBySolutionIdAsync(solutionId));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUniques")]
        public async Task<ActionResult<InvestmentEntityDto>> GetUniquesNames(int solutionId)
        {
            try
            {
                return Ok(await repository.GetUniqueNames(solutionId));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getOneInvesmentByProjectId")]
        public async Task<ActionResult> GetOneInvesmentAsync(int id)
        {
            try
            {
                return Ok(await repository.GetOneInvesmentAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var projectDto = (await repository.GetAsync(id));

                return Ok(projectDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetByProjectIdAsync")]
        public async Task<ActionResult<InvestmentEntityDto>> GetByProjectIdAsync(int projectId)
        {
            try
            {
                return Ok(await repository.GetByProjectIdAsync(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
