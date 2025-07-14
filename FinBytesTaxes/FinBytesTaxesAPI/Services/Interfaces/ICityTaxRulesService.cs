using FinBytesTaxesAPI.Models.Dto;

namespace FinBytesTaxesAPI.Services.Interfaces
{
    public interface ICityTaxRulesService
    {
        Task<decimal?> GetRateByCityAndDateAsync(int cityId, DateOnly date);
        Task CreateAsync(CreateCityTaxRuleDto cityTaxRuleDto);
        Task UpdateAsync(int id, UpdateCityTaxRuleDto cityTaxRuleDto);
        Task DeleteAsync(int id);
    }
}
