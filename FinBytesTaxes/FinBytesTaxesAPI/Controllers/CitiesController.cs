using FinBytesTaxesAPI.Attributes;
using FinBytesTaxesAPI.Repositories.Interfaces;
using FinBytesTaxesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinBytesTaxesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequireRoleHeader]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
           var cities = await _citiesService.GetAllAsync();

           return Ok(cities);
        }
    }
}
