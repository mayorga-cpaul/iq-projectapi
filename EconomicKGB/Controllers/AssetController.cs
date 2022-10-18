using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/asset")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetApplication repository;
        public AssetController(IAssetApplication repository)
        {
            this.repository = repository;
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateProjecCostAsync(int id, AssetDto aseetDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                bool result = await repository.UpdateAsync(id, aseetDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("getAssets")]
        public async Task<ActionResult<ProjectCostDto>> GetAllCostAsync(Int32 assetId)
        {
            try
            {
                var projectCost = await repository.GetAllAssetAsync(assetId);

                return Ok(projectCost);
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
        public async Task<ActionResult> DeleteProjectCostAsync(int id)
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
        public async Task<ActionResult> SetCostAsync(AssetDto assetDto)
        {
            try
            {
                return Ok(await repository.SetAssetAsync(assetDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
