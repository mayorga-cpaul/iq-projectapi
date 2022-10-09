using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/cost")]
    public class CostController : ControllerBase
    {
        private readonly ICostApplication repository;
        public CostController(ICostApplication repository)
        {
            this.repository = repository;
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateProjecCostAsync(Int32 Id, ProjectCostDto projectCostDto)
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

        [HttpGet]
        [Route("api/getCost")]
        public async Task<ActionResult<ProjectCostDto>> GetAllCostAsync(Int32 projectId)
        {
            try
            {
                var projectCost = await repository.GetAllCostAsync(projectId);

                return Ok(projectCost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Id")]
        public async Task<ActionResult> DeleteProjectCostAsync(int id)
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
        public async Task<ActionResult> SetCostAsync(ProjectCostDto costProjects)
        {
            try
            {
                return Ok(await repository.SetCostAsync(costProjects));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
