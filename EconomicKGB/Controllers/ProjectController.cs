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
        public async Task<ActionResult> SetProjectToSolutionAsync(ProjectDto projectDto)
        {
            try
            {
                return Ok(await repository.SetProjectToSolutionAsync(projectDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(int id, ProjectDto projectDto)
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

                var result = await repository.RemoveProject(id);

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
        public async Task<ActionResult<ProjectDto>> GetProjectsBySolAsync(int solutionId)
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
        [Route("getLast")]
        public async Task<ActionResult> GetLastAdded()
        {
            try
            {
                var solutionDto = (await repository.LastCreated());

                return Ok(solutionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}