using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectApplication repository;
        public ProjectController(IProjectApplication projectApplication)
        {
            this.repository = projectApplication;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(ProjectDto projectDto)
        {
            try
            {
                return Ok(await repository.CreateAsync(projectDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{Id}")]
        public async Task<ActionResult> UpdateAsync(Int32 id, ProjectDto projectDto)
        {
            try
            {
                return Ok(await repository.UpdateAsync(id, projectDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{projectid}")]
        public async Task<ActionResult> GetByIdAsync(Int32 projectid)
        {
            try
            {
                var projectDto = (await repository.GetAsync(projectid));

                return Ok(projectDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{projectid}")]
        public async Task<ActionResult> DeleteAsync(Int32 projectid)
        {
            try
            {
                var existingItem = await repository.GetAsync(projectid);

                if (existingItem is null)
                {
                    return NotFound();
                }

                int result = await repository.DeleteAsync(projectid);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ProjectDto>> GetAllAsync()
        {
            try
            {
                var projects = (await repository.GetAllAsync());

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #region new methods
        [HttpGet]
        [Route("getprojectsbysolutionid")]
        public async Task<ActionResult<ProjectDto>> GetProjectsBySolAsync(Int32 solutionId)
        {
            try
            {
                var projects = (await repository.GetProjectsBySolAsync(solutionId));
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getentries")]
        public async Task<ActionResult<ProjectEntryDto>> GetAllEntriesAsync(Int32 projectid)
        {
            try
            {
                var projects = (await repository.GetEntriesAsync(projectid));

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("setentries")]
        public async Task<ActionResult> SetEntryToProjectAsync(IEnumerable<ProjectEntryDto> projectEntries, Int32 projectid)
        {
            try
            {
                return Ok(await repository.SetEntriesAsync(projectEntries, projectid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}