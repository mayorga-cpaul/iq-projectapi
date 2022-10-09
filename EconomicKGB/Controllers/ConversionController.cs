using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;
using System.Net;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/conversion")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionApplication repository;
        public ConversionController(IConversionApplication repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ConversionDto>> GetAllAsync()
        {
            try
            {
                var items = (await repository.GetAllAsync());

                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("email")]
        public async Task<ActionResult<ConversionDto>> FindByUserEmailAsync(string email)
        {
            try
            {
                var items = (await repository.FindByUserEmailAsync(email));

                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<ConversionDto>> CreateConversionAsync(ConversionDto conversionDto)
        {
            try
            {
                await repository.CreateAsync(conversionDto);

                return Ok("Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch]
        public async Task<ActionResult> UpdateConversionAsync(int id, ConversionDto conversionDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                bool result = await repository.UpdateAsync(id, conversionDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConversionAsync(int id)
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
    }
}
