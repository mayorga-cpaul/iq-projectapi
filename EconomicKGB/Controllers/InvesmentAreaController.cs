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

        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(int id, InvesmentAreaDto projectCostDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                bool result = await repository.UpdateAsync(id, projectCostDto);

                return Ok(result);
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

                int result = await repository.DeleteAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SetInvesmentAsync(InvesmentAreaDto gastoProjects)
        {
            try
            {
                return Ok(await repository.SetInvesmentArea(gastoProjects));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<InvesmentAreaDto>> GetInvesments(int projectId)
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
