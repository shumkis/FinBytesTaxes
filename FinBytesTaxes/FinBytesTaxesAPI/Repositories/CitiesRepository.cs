using FinBytesTaxesAPI.Data;
using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinBytesTaxesAPI.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly AppDbContext _appDbContext;

        public CitiesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _appDbContext.Cities.ToListAsync();
        }
    }
}
