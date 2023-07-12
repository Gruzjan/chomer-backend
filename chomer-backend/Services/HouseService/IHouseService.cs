using chomer_backend.Models;

namespace chomer_backend.Services.HouseService
{
    public interface IHouseService
    {
        Task<List<House>> CreateHouse(House house);
        Task<List<House>> UpdateHouse(int houseId, House request);
        Task<List<House>> DeleteHouse(int houseId);
    }
}
