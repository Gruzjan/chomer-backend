using chomer_backend.Models;
using chomer_backend.Models.DTO;

namespace chomer_backend.Services.HouseService
{
    public interface IHouseService
    {
        Task<House?> CreateHouse(CreateHouseDTO house);
        Task<List<House>> GetHouses();
        Task<House?> GetHouseById(int houseId, IList<string> includeProperties = null);
        Task<House?> UpdateHouse(int houseId, House request);
        Task<House?> DeleteHouse(int houseId);
    }
}
