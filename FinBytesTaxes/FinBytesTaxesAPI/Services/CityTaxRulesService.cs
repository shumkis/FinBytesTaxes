using AutoMapper;
using FinBytesTaxesAPI.Helpers;
using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;
using FinBytesTaxesAPI.Repositories.Interfaces;
using FinBytesTaxesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<decimal> GetAvgRateAsync(int cityId, [FromQuery] DateOnly dateFrom, DateOnly dateTo)
        {
            var schedule = await GetTaxScheduleAsync(cityId, dateFrom, dateTo);

            var allRateSum = schedule.Sum(x => x.Rate ?? 0);
            var average = Math.Round(allRateSum / schedule.Count, 2);
            
            return average;
        }

        public async Task<List<TaxScheduleItemDto>> GetTaxScheduleAsync(int cityId, [FromQuery] DateOnly dateFrom, DateOnly dateTo)
        {
            if (dateFrom > dateTo)
            {
                throw new ValidationException("DateFrom value cannot be bigger thant DateTo value");
            }

            var result = new List<TaxScheduleItemDto>();

            var dates = DateHelper.RangeToDateList(dateFrom, dateTo);
            var rules = await _cityTaxRulesRepository.GetAllByCityAndDateRangeAsync(cityId, dateFrom, dateTo);

            foreach (var date in dates)
            {
                result.Add(GetTaxScheduleItemFromRules(date, rules));
            }

            return result;

        }

        public async Task<decimal?> GetRateByCityAndDateAsync(int cityId, DateOnly date)
        {
            var rule = await _cityTaxRulesRepository.GetRuleByCityAndDateAsync(cityId, date);

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
                throw new ValidationException($"Rule for cityId {cityTaxRuleDto.CityId} of type {cityTaxRuleDto.TaxTypeId} " +
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

        private TaxScheduleItemDto GetTaxScheduleItemFromRules(DateOnly date, IEnumerable<CityTaxRule> rules)
        {
            var rule = rules.FirstOrDefault(x => x.StartDate <= date && x.EndDate >= date);

            return new TaxScheduleItemDto
            {
                Date = date,
                Rate = rule?.Rate
            };
        }
    }
}
