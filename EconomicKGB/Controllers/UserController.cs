using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication repository;
        public UserController(IUserApplication repository)
        {
            this.repository = repository;
        }

        #region CRUD

        [HttpPost]
        public async Task<ActionResult> CreateAsync(UserDto solutionDto)
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
        public async Task<ActionResult> UpdateAsync(Int32 id, UserDto solutionDto)
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

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetByIdAsync(Int32 userId)
        {
            try
            {
                var userDto = (await repository.GetAsync(userId));

                return Ok(userDto);
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
                var existingItem = await repository.GetAsync(userId);

                if (existingItem is null)
                {
                    return NotFound();
                }

                int result = await repository.DeleteAsync(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAllAsync()
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

        #region Get

        [HttpGet]
        [Route("getbyname")]
        public async Task<ActionResult> GetByNameAsync(string name)
        {
            try
            {
                var projects = (await repository.GetByNameAsync(name));

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getbyemail")]
        public async Task<ActionResult> GetByEmailAsync(string name)
        {
            try
            {
                var projects = (await repository.GetByEmailAsync(name));

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //TODO: ya hay un metodo del controller de la solucion que hace lo mismo 
        [HttpGet]
        [Route("getsolutions/userid")]
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
        #endregion

        #region Others 

        [HttpGet]
        [Route("others/access")]
        public async Task<ActionResult> AccessToAppAsync(string email, string name, string password)
        {
            try
            {
                var projects = await repository.AccessToAppAsync(email, name, password);

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("others/existemail")]
        public async Task<ActionResult> ExistEmailAsync(string email)
        {
            try
            {
                var projects = await repository.ExistEmailAsync(email);

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("others/recoverpassword")]

        public async Task<ActionResult> RecoveryPasswordAsync(string email)
        {
            try
            {
                var projects = await repository.RecoveryPasswordAsync(email);

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
