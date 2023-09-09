using AutoMapper;
using chomer_backend.Data;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.HouseUserService;
using Microsoft.EntityFrameworkCore;

namespace chomer_backend.Services.HouseService
{
    public class HouseService : IHouseService
    {
        private readonly DataContext _context;
        private readonly IHouseUserService _HUservice;
        public HouseService(DataContext context, IHouseUserService service)
        {
            _HUservice = service;
            _context = context;
        }
        public async Task<House?> CreateHouse(House house)
        {
            var user = await _context.Users.FindAsync(house.OwnerId);
            if (user == null)
                return null;
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
            var houseuser = await _HUservice.CreateHouseUserByUserId(house.Id, house.OwnerId, true);
            if (houseuser == null)
                return null;
            await _context.SaveChangesAsync();
            return house;
        }
        public async Task<List<House>> GetHouses()
        {
            return await _context.Houses.ToListAsync();
        }
        public async Task<House?> GetHouseById(int id, IList<string> includeProperties = null)
        {
            IQueryable<House> query = _context.Houses;
            if (includeProperties != null)
                foreach (var prop in includeProperties)
                    query = query.Include(prop);
            var house = await query.FirstOrDefaultAsync(h => h.Id == id);
            if (house == null)
                return null;
            return house;
        }
        public async Task<House?> UpdateHouse(int id, House request)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
                return null;
            if (request == null)
                return null;
            house.OwnerId = request.OwnerId;
            house.Name = request.Name;
            await _context.SaveChangesAsync();
            return house;
        }
        public async Task<House?> DeleteHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
                return null;
            _context.Chores.RemoveRange(house.Chores);
            _context.HouseUsers.RemoveRange(house.HouseUsers);
            _context.Rewards.RemoveRange(house.Rewards);
            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return house;
        }
    }
}
