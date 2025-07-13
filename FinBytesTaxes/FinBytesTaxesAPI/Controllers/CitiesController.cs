using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinBytesTaxesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ICitiesRepository citiesRepository, ILogger<CitiesController> logger)
        {
            _citiesRepository = citiesRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
           var cities = await _citiesRepository.GetAllAsync();

           return Ok(cities);
        }
    }
}
