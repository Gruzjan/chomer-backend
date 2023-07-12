using chomer_backend.Data;
using chomer_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chomer_backend.Services.HouseUserService
{
    public class HouseUserService : IHouseUserService
    {
        private readonly DataContext _context;
        public HouseUserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<HouseUser>> CreateHouseUser(HouseUser user)
        {
            _context.HouseUsers.Add(user);
            await _context.SaveChangesAsync();
            return await _context.HouseUsers.ToListAsync();
        }

        public async Task<List<HouseUser>?> CreateHouseUserByEmail(int houseId, string email)
        {
            var user = await _context.Users
                .Where(u => u.Email.Equals(email))
                .FirstOrDefaultAsync();
            if (user == null)
                return null;
            var house = await _context.Houses.FindAsync(houseId);
            if (house == null)
                return null;
            var houseUser = _context.HouseUsers.Add(new HouseUser
            {
                HouseId = houseId,
                UserId = user.Id,
            });
            await _context.SaveChangesAsync();
            return await _context.HouseUsers.ToListAsync();
        }

        public async Task<List<HouseUser>> GetHouseUsersById(int houseId)
        {
            return await _context.HouseUsers
                .Where(hu => hu.HouseId == houseId)
                .ToListAsync();
        }
    }
}
