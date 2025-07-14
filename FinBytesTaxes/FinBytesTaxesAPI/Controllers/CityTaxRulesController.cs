using FinBytesTaxesAPI.Attributes;
using FinBytesTaxesAPI.Constants;
using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;
using FinBytesTaxesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinBytesTaxesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequireRoleHeader]
    public class CityTaxRulesController : ControllerBase
    {
        private readonly ICityTaxRulesService _cityTaxRulesService;

        public CityTaxRulesController(ICityTaxRulesService cityTaxRulesService)
        {
            _cityTaxRulesService = cityTaxRulesService;
        }

        [HttpGet("rate/{cityId}")]
        public async Task<ActionResult> GetRateByCityAndDateAsync(int cityId, [FromQuery] DateOnly date)
        {
           var rate = await _cityTaxRulesService.GetRateByCityAndDateAsync(cityId, date);

           return Ok(rate);
        }

        [RequireRoleHeader(Const.AdminRoleName)]
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCityTaxRuleDto cityTaxRule)
        {
            await _cityTaxRulesService.CreateAsync(cityTaxRule);

            return Ok();
        }

        [RequireRoleHeader(Const.AdminRoleName)]
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateCityTaxRuleDto cityTaxRule)
        {
            await _cityTaxRulesService.UpdateAsync(id, cityTaxRule);

            return Ok();
        }

        [RequireRoleHeader(Const.AdminRoleName)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _cityTaxRulesService.DeleteAsync(id);

            return Ok();
        }
    }
}
