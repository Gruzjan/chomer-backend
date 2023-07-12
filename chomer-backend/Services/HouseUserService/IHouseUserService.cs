using chomer_backend.Models;

namespace chomer_backend.Services.HouseUserService
{
    public interface IHouseUserService
    {
        Task<List<HouseUser>?> CreateHouseUserByEmail(int houseId, string email);
        Task<List<HouseUser>> GetHouseUsersById(int houseId);
    }
}
