using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;
using FinBytesTaxesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinBytesTaxesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityTaxRulesController : ControllerBase
    {
        private readonly ICityTaxRulesService _cityTaxRulesService;

        public CityTaxRulesController(ICityTaxRulesService cityTaxRulesService)
        {
            _cityTaxRulesService = cityTaxRulesService;
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult> GetRateByCityAndDateAsync(int cityId, [FromQuery] DateOnly date)
        {
           var rate = await _cityTaxRulesService.GetRateByCityAndDateAsync(cityId, date);

           return Ok(rate);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCityTaxRuleDto cityTaxRule)
        {
            await _cityTaxRulesService.CreateAsync(cityTaxRule);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateCityTaxRuleDto cityTaxRule)
        {
            await _cityTaxRulesService.UpdateAsync(id, cityTaxRule);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _cityTaxRulesService.DeleteAsync(id);

            return Ok();
        }
    }
}
