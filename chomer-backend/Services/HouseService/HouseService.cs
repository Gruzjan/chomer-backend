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

        public async Task<List<House>?> DeleteHouse(int houseId)
        {
            var house = await _context.Houses.FindAsync(houseId);
            if (house == null)
                return null;
            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return await _context.Houses.ToListAsync();
        }

        public async Task<House?> GetHouseById(int houseId)
        {
            var house = await _context.Houses.FindAsync(houseId);
            if(house == null)
                return null;
            return house;
        }

        public Task<List<House>> GetHouses()
        {
            throw new NotImplementedException();
        }

        public async Task<List<House>?> UpdateHouse(int houseId, House request)
        {
            var house = await _context.Houses.FindAsync(houseId);
            if (house == null)
                return null;
            house.OwnerId = request.OwnerId;
            house.Name = request.Name;
            await _context.SaveChangesAsync();
            return await _context.Houses.ToListAsync();
        }
    }
}
