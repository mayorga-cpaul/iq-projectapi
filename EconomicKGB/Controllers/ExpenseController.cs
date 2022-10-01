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

        [HttpPatch("{Id}, {ProjectExpenseDto}")]
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

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteAsync(Int32 id)
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
        public async Task<ActionResult> SetExpensesAsync(IEnumerable<ProjectExpenseDto> gastoProjects, Int32 projectId)
        {
            try
            {
                return Ok(await repository.SetExpenseAsync(gastoProjects, projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
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
