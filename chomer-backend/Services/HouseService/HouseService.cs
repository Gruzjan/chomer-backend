using chomer_backend.Data;
using chomer_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chomer_backend.Services.HouseService
{
    public class HouseService : IHouseService
    {
        private readonly DataContext _context;
        public HouseService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<House>> CreateHouse(House house)
        {
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
            return await _context.Houses.ToListAsync();
        }

        public async Task<List<House>?> DeleteHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
                return null;
            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return await _context.Houses.ToListAsync();
        }

        public async Task<House?> GetHouseById(int id, IList<string> includeProperties = null)
        {
            var query = _context.Houses;
            if (includeProperties != null)
                foreach (var prop in includeProperties)
                    query.Include(prop);
            var house = await query.FirstOrDefaultAsync(h => h.Id == id);
            if (house == null)
                return null;
            return house;
        }

        public async Task<List<House>> GetHouses()
        {
            return await _context.Houses.ToListAsync();
        }

        public async Task<List<House>?> UpdateHouse(int id, House request)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
                return null;
            if (request == null)
                return null;
            house.OwnerId = request.OwnerId;
            house.Name = request.Name;
            await _context.SaveChangesAsync();
            return await _context.Houses.ToListAsync();
        }
    }
}
