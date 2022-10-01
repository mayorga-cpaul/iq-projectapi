using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using SmartSolution.Domain.Entities.EntitiesBase;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/invesmentArea")]
    public class InvesmentAreaController : ControllerBase
    {
        private readonly IInvesmentAreaApplication repository;
        public InvesmentAreaController(IInvesmentAreaApplication repository)
        {
            this.repository = repository;
        }

        [HttpPatch("{Id}, {InvesmentAreaDto}")]
        public async Task<ActionResult> UpdateAsync(Int32 Id, InvesmentAreaDto projectCostDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(Id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                bool result = await repository.UpdateAsync(Id, projectCostDto);

                return Ok(result);
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

                int result = await repository.DeleteAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SetInvesmentAsync(IEnumerable<InvesmentAreaDto> gastoProjects, Int32 projectId)
        {
            try
            {
                return Ok(await repository.SetInvesmentArea(gastoProjects, projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<InvesmentAreaDto>> GetInvesments(Int32 projectId)
        {
            try
            {
                return Ok(await repository.GetProjects(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
