using chomer_backend.Models;

namespace chomer_backend.Services.HouseUserService
{
    public interface IHouseUserService
    {
        Task<List<HouseUser>?> CreateHouseUserByEmail(int houseId, string email);
        Task<List<HouseUser>> GetHouseUsers();
        Task<HouseUser?> GetHouseUserById(int id);
        Task<List<HouseUser>?> GetHouseUsersByHouseId(int houseId);
        Task<HouseUser?> UpdateHouseUser(int id, HouseUser request);
        Task<List<HouseUser>?> DeleteHouseUser(int id);
    }
}
