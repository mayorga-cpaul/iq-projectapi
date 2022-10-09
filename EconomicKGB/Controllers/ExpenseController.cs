using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/expense")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseApplication repository;
        public ExpenseController(IExpenseApplication repository)
        {
            this.repository = repository;
        }
        #region CRUD 

        [HttpGet]
        public async Task<ActionResult<ProjectExpenseDto>> GetAllAsync()
        {
            try
            {
                var expenses = (await repository.GetAllAsync());

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int expenseid)
        {
            try
            {
                var projectDto = (await repository.GetAsync(expenseid));

                return Ok(projectDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateAsync(Int32 Id, ProjectExpenseDto projectCostDto)
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
        #endregion

        [HttpPost("setExpenseAsync")]
        public async Task<ActionResult> SetExpensesAsync(ProjectExpenseDto gastoProjects)
        {
            try
            {
                return Ok(await repository.SetExpenseAsync(gastoProjects));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getexpensesbyprojectid")]
        public async Task<ActionResult<ProjectExpenseDto>> GetAllExpense(Int32 projectId)
        {
            try
            {
                return Ok(await repository.GetAllExpenses(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
