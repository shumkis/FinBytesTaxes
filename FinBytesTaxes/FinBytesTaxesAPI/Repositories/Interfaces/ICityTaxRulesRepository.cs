using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;

namespace FinBytesTaxesAPI.Repositories.Interfaces
{
    public interface ICityTaxRulesRepository
    {
        Task<IEnumerable<CityTaxRule>> GetAllByCityAndDateRangeAsync(int cityId, DateOnly dateFrom, DateOnly dateTo);

        Task<CityTaxRule?> GetRuleByCityAndDateAsync(int cityId, DateOnly date);

        Task<bool> Exists(CreateCityTaxRuleDto cityTaxRuleDto);

        Task CreateAsync(CityTaxRule cityTaxRule);

        Task UpdateAsync(int id, UpdateCityTaxRuleDto cityTaxRuleDto);

        Task DeleteAsync(int id);
    }
}
