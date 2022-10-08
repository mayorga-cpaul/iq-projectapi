using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/solution")]
    public class SolutionController : ControllerBase
    {
        private readonly ISolutionApplication repository;
        public SolutionController(ISolutionApplication repository)
        {
            this.repository = repository;
        }

        #region CRUD

        [HttpPost]
        public async Task<ActionResult> CreateAsync(SolutionDto solutionDto)
        {
            try
            {
                return Ok(await repository.CreateAsync(solutionDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(Int32 id, SolutionDto solutionDto)
        {
            try
            {
                return Ok(await repository.UpdateAsync(id, solutionDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idsolution}")]
        public async Task<ActionResult> GetByIdAsync(Int32 idsolution)
        {
            try
            {
                var solutionDto = (await repository.GetAsync(idsolution));

                return Ok(solutionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{solutionid}")]
        public async Task<ActionResult> DeleteAsync(Int32 solutionid)
        {
            try
            {
                var existingItem = await repository.GetAsync(solutionid);

                if (existingItem is null)
                {
                    return NotFound();
                }

                int result = await repository.DeleteAsync(solutionid);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<SolutionDto>> GetAllAsync()
        {
            try
            {
                var solutionDtos = (await repository.GetAllAsync());

                return Ok(solutionDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region Set

        [HttpPost]
        [Route("setprojects")]
        public async Task<ActionResult> SetProjectToSolutionAsync(IEnumerable<ProjectDto> projectDtos, Int32 solutionid)
        {
            try
            {
                return Ok(await repository.SetProjectToSolutionAsync(projectDtos, solutionid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("setoneproject")]
        public async Task<ActionResult> SetOneProjectToSolutionAsync(Int32 projectId, Int32 solutionId)
        {
            try
            {
                return Ok(await repository.SetOneProjectToSolutionAsync(projectId, solutionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Get

        [HttpGet]
        [Route("getsolutionsbyuserid")]

        public async Task<ActionResult<SolutionDto>> GetByUserAsync(Int32 userId)
        {
            try
            {
                var projects = (await repository.GetByUserAsync(userId));

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //TODO: este método del controller de la solucion tiene la misma finalidad que uno del controller de proyectos
        [HttpGet]
        [Route("getprojectsbysolutionid")]

        public async Task<ActionResult<ProjectDto>> GetAllProjectsAsync(Int32 solutionId)
        {
            try
            {
                var projects = (await repository.GetAllProjectsAsync(solutionId));

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("getsolutionsbyid")]
        //TODO: ya hay un metodo con esta misma funcionalidad
        public async Task<ActionResult> GetSolutionByIdAsync(Int32 solutionId)
        {
            try
            {
                var projects = (await repository.GetSolutionByIdAsync(solutionId));

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("getsolutionsbyemail")]
        public async Task<ActionResult> GetSolutionByEmailAsync(string email)
        {
            try
            {
                var projects = (await repository.GetByUserEmailAsync(email));

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

    }
}
