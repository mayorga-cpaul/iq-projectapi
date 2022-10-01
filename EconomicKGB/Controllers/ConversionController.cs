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

        [HttpPatch("{Id}, {ConversionDto}")]
        public async Task<ActionResult> UpdateConversionAsync(Int32 Id, ConversionDto conversionDto)
        {
            try
            {
                var existingItem = await repository.GetAsync(Id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                bool result = await repository.UpdateAsync(Id, conversionDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteConversionAsync(Int32 id)
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
