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
        public async Task<ActionResult> CreateAsync(UserDto userDto)
        {
            try
            {
                return Ok(await repository.CreateAsync(userDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(int id, UserDto userDto)
        {
            try
            {
                return Ok(await repository.UpdateAsyncWithSp(userDto, id));
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
                var userDto = (await repository.GetAsync(id));

                return Ok(userDto);
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
        #endregion

        #region Others 

        [HttpGet]
        [Route("others/access")]
        public async Task<ActionResult> AccessToAppAsync(string email, string password)
        {
            try
            {
                var projects = await repository.AccessToAppAsync(email, password);

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
