using FinBytesTaxesAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FinBytesTaxesAPI.Services.Interfaces
{
    public interface ICityTaxRulesService
    {
        Task<decimal> GetAvgRateAsync(int cityId, [FromQuery] DateOnly dateFrom, DateOnly dateTo);
        Task<List<TaxScheduleItemDto>> GetTaxScheduleAsync(int cityId, [FromQuery] DateOnly dateFrom, DateOnly dateTo);
        Task<decimal?> GetRateByCityAndDateAsync(int cityId, DateOnly date);
        Task CreateAsync(CreateCityTaxRuleDto cityTaxRuleDto);
        Task UpdateAsync(int id, UpdateCityTaxRuleDto cityTaxRuleDto);
        Task DeleteAsync(int id);
    }
}
