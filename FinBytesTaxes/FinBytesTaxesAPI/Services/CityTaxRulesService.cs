using AutoMapper;
using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;
using FinBytesTaxesAPI.Repositories.Interfaces;
using FinBytesTaxesAPI.Services.Interfaces;

namespace FinBytesTaxesAPI.Services
{
    public class CityTaxRulesService : ICityTaxRulesService
    {
        private readonly ICityTaxRulesRepository _cityTaxRulesRepository;
        private readonly IMapper _mapper;

        public CityTaxRulesService(ICityTaxRulesRepository cityTaxRulesRepository, IMapper mapper)
        {
            _cityTaxRulesRepository = cityTaxRulesRepository;
            _mapper = mapper;
        }

        public async Task<decimal?> GetRateByCityAndDateAsync(int cityId, DateOnly date)
        {
            var rule = await _cityTaxRulesRepository.GetByCityAndDateAsync(cityId, date);

            if (rule != null)
            {
                return rule.Rate;
            }

            return null;
        }

        public async Task CreateAsync(CreateCityTaxRuleDto cityTaxRuleDto)
        {
            var exists = await _cityTaxRulesRepository.Exists(cityTaxRuleDto);

            if (exists)
            {
                throw new Exception($"Rule for cityId {cityTaxRuleDto.CityId} of type {cityTaxRuleDto.TaxTypeId} " +
                    $"already exists for this date range {cityTaxRuleDto.StartDate} - {cityTaxRuleDto.EndDate}");
            }
            else
            {
                var cityTaxRule = _mapper.Map<CityTaxRule>(cityTaxRuleDto);
                await _cityTaxRulesRepository.CreateAsync(cityTaxRule);
            }
        }

        public async Task UpdateAsync(int id, UpdateCityTaxRuleDto cityTaxRuleDto)
        {
            await _cityTaxRulesRepository.UpdateAsync(id, cityTaxRuleDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _cityTaxRulesRepository.DeleteAsync(id);
        }
    }
}
