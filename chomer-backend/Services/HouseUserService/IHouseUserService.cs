using chomer_backend.Models;

namespace chomer_backend.Services.HouseUserService
{
    public interface IHouseUserService
    {
        Task<HouseUser?> CreateHouseUserByUserId(int houseId, int userId, bool isAdmin = false);
        Task<HouseUser?> CreateHouseUserByEmail(int houseId, string email, bool isAdmin = false);
        Task<List<HouseUser>> GetHouseUsers();
        Task<HouseUser?> GetHouseUserById(int id, IList<string> includeProperties = null);
        Task<List<HouseUser>?> GetHouseUsersByHouseId(int houseId);
        Task<HouseUser?> UpdateHouseUser(int id, HouseUser request);
        Task<HouseUser?> DeleteHouseUser(int id);
    }
}
