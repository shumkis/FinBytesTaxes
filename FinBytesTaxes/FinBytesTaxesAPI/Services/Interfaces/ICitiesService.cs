using FinBytesTaxesAPI.Models.Dto;

namespace FinBytesTaxesAPI.Services.Interfaces
{
    public interface ICitiesService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
    }
}
