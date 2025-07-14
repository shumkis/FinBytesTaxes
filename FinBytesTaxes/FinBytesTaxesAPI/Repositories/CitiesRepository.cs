using FinBytesTaxesAPI.Data;
using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinBytesTaxesAPI.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly AppDbContext _db;

        public CitiesRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _db.Cities.AsNoTracking().ToListAsync();
        }
    }
}
