using AutoMapper;
using FinBytesTaxesAPI.Models.Dto;
using FinBytesTaxesAPI.Repositories.Interfaces;
using FinBytesTaxesAPI.Services.Interfaces;

namespace FinBytesTaxesAPI.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IMapper _mapper;

        public CitiesService(ICitiesRepository citiesRepository, IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var cities = await _citiesRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CityDto>>(cities);
        }
    }
}
