using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;

namespace FinBytesTaxesAPI.Repositories.Interfaces
{
    public interface ICityTaxRulesRepository
    {
        Task<CityTaxRule?> GetByCityAndDateAsync(int cityId, DateOnly date);

        Task<bool> Exists(CreateCityTaxRuleDto cityTaxRuleDto);

        Task CreateAsync(CityTaxRule cityTaxRule);

        Task UpdateAsync(int id, UpdateCityTaxRuleDto cityTaxRuleDto);

        Task DeleteAsync(int id);
    }
}
