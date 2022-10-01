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

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetByIdAsync(Int32 userId)
        {
            try
            {
                var projectDto = (await repository.GetAsync(userId));

                return Ok(projectDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteAsync(Int32 userId)
        {
            try
            {
                var projectDto = (await repository.GetAsync(userId));

                return Ok(projectDto);
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
    }
}