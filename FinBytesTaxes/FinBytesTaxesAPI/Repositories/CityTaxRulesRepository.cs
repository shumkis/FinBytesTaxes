using FinBytesTaxesAPI.Data;
using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;
using FinBytesTaxesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinBytesTaxesAPI.Repositories
{
    public class CityTaxRulesRepository : ICityTaxRulesRepository
    {
        private readonly AppDbContext _db;

        public CityTaxRulesRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CityTaxRule>> GetAllByCityAndDateRangeAsync(int cityId, DateOnly dateFrom, DateOnly dateTo)
        {
            return await _db.CityTaxRules.AsNoTracking()
                .Include(x => x.TaxType)
                .Where(x => x.CityId == cityId && x.StartDate <= dateTo && x.EndDate >= dateFrom)
                .OrderBy(x => x.TaxType.Priority)
                .ToListAsync();
        }

        public async Task<CityTaxRule?> GetRuleByCityAndDateAsync(int cityId, DateOnly date)
        {
            return await _db.CityTaxRules.AsNoTracking()
                .OrderBy(x => x.TaxType.Priority)
                .FirstOrDefaultAsync(x => x.CityId == cityId && x.StartDate >= date && x.EndDate <= date);
        }

        public async Task<bool> Exists(CreateCityTaxRuleDto cityTaxRuleDto)
        {
            return await _db.CityTaxRules.AnyAsync(x => x.CityId == cityTaxRuleDto.CityId && x.TaxTypeId == cityTaxRuleDto.TaxTypeId
                                            && x.StartDate == cityTaxRuleDto.StartDate && x.EndDate == x.EndDate);
        }

        public async Task CreateAsync(CityTaxRule cityTaxRule)
        {
            _db.CityTaxRules.Add(cityTaxRule);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateCityTaxRuleDto cityTaxRuleDto)
        {
            var item = await _db.CityTaxRules.FirstAsync(x => x.Id == id);

            item.StartDate = cityTaxRuleDto.StartDate;
            item.EndDate = cityTaxRuleDto.EndDate;
            item.Rate = cityTaxRuleDto.Rate;

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _db.CityTaxRules.FirstAsync(x => x.Id == id);

            _db.CityTaxRules.Remove(item);

            await _db.SaveChangesAsync();
        }

    }
}
