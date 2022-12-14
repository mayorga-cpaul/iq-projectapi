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


        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(int id, SolutionDto solutionDto)
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

        [HttpGet]
        [Route("getLast")]
        public async Task<ActionResult> GetLastAdded()
        {
            try
            {
                var solutionDto = (await repository.LastCreatedAsync());

                return Ok(solutionDto);
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
                var solutionDto = (await repository.GetAsync(id));

                return Ok(solutionDto);
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
        public async Task<ActionResult> SetSolutionAsync(SolutionDto solution)
        {
            try
            {
                return Ok(await repository.SetSolutionToUserAsync(solution));
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

        public async Task<ActionResult<SolutionDto>> GetByUserAsync(int userId)
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

        [HttpGet]
        [Route("getsolutionsbyid")]
        public async Task<ActionResult> GetSolutionByIdAsync(int id)
        {
            try
            {
                var projects = (await repository.GetSolutionByIdAsync(id));

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
