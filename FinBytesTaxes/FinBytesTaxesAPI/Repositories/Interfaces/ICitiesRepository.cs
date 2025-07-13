using FinBytesTaxesAPI.Models.Db;

namespace FinBytesTaxesAPI.Repositories.Interfaces
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
    }
}
