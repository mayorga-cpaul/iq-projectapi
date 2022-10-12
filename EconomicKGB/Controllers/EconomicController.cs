using Microsoft.AspNetCore.Mvc;
using SmartSolution.Application.Dtos.Economic;
using SmartSolution.Application.Dtos.EntitiesDto;
using SmartSolution.Application.Interfaces.IRepositories;

namespace SmartSolution.API.Controllers
{
    [ApiController]
    [Route("api/economic")]
    public class EconomicController : ControllerBase
    {
        private readonly IEconomicApplication repository;
        public EconomicController(IEconomicApplication repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<EconomicDto>> GetAllEconomicAsync()
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

        [HttpGet]
        [Route("findByUseremail")]
        public async Task<ActionResult<EconomicDto>> FindByUserEmailEconomicAsync(string email)
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
        

        [HttpGet]
        [Route("interes/{solutionId}")]
        public async Task<ActionResult<RateDto>> GetInteresAsync(Int32 solutionId)
        {
            try
            {
                var interest = (await repository.GetInterestAsync(solutionId));

                return Ok(interest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        [HttpGet]
        [Route("anualidad/{solutionId}")]
        public async Task<ActionResult<AnnuityDto>> GetAnualidadesAsync(Int32 solutionId)
        {
            try
            {
                var annuatyies = (await repository.GetAnnuitiesAsync(solutionId));

                return Ok(annuatyies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        [HttpGet]
        [Route("{solutionId}")]
        public async Task<ActionResult<EconomicDto>> GetPureEconomicAsync(Int32 solutionId)
        {
            try
            {
                var items = (await repository.GetEconomicsBySolutionAsync(solutionId));

                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //TODO: Quite el createFlow de aqui 

        //[HttpPost]
        //[Route("flow/{economics}")]
        //public async Task<ActionResult<EconomicDto>> CreateCashFlowsAsync(List<EconomicDto> economics, Int32 nper)
        //{
        //    try
        //    {
        //        await repository.CreateCashFlowAsync(economics, nper);

        //        return Ok("Created");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        
        [HttpPost]
        //[Route("create/{economic}")]
        public async Task<ActionResult<EconomicDto>> CreateEconomicAsync(EconomicDto economicDto)
        {
            try
            {
                await repository.CreateAsync(economicDto);

                return Ok("Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPatch]
        [Route("{Id}")]
        public async Task<ActionResult> UpdateEconomicAsync(Int32 Id, EconomicDto economicDto)
        {
            try
            {
                var existingEconomic = await repository.GetAsync(Id);

                if (existingEconomic == null)
                {
                    return NotFound();
                }

                bool result = await repository.UpdateAsync(Id, economicDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEconomicAsync(Int32 id)
        {
            try
            {
                var existingEconomic = await repository.GetAsync(id);

                if (existingEconomic is null)
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
