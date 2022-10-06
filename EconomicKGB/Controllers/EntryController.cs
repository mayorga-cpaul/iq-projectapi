using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSolution.API.Controllers
{
    [Route("api/entry")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryApplication repository;

        public EntryController(IEntryApplication repository)
        {
            this.repository = repository;
        }


        [HttpPatch]
        public async Task<ActionResult> UpdateProjecCostAsync(Int32 Id, ProjectEntryDto projectEntryDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(Id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                bool result = await repository.UpdateAsync(Id, projectEntryDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEntryDto>> GetAllEntryAsync(Int32 projectId)
        {
            try
            {
                var projectEntry = await repository.GetAllEntryAsync(projectId);

                return Ok(projectEntry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProjectEntryAsync(Int32 id)
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
        public async Task<ActionResult> SetEntryAsync(IEnumerable<ProjectEntryDto> entryProjects, Int32 projectId)
        {
            try
            {
                return Ok(await repository.SetEntryAsync(entryProjects, projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
