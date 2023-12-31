﻿using chomer_backend.Data;
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
        public async Task<HouseUser?> CreateHouseUserByUserId(int houseId, int userId, bool isAdmin = false)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return null;
            var house = await _context.Houses.FindAsync(houseId);
            if (house == null)
                return null;
            var houseUser = _context.HouseUsers.Add(new HouseUser
            {
                HouseId = houseId,
                UserId = user.Id,
                House = house,
                User = user,
                IsAdmin = isAdmin
            });
            await _context.SaveChangesAsync();
            return houseUser.Entity;
        }
        public async Task<HouseUser?> CreateHouseUserByEmail(int houseId, string email, bool isAdmin = false)
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
                House = house,
                User = user,
                IsAdmin = isAdmin
            });
            await _context.SaveChangesAsync();
            return houseUser.Entity;
        }
        public async Task<List<HouseUser>> GetHouseUsers()
        {
            return await _context.HouseUsers.ToListAsync();
        }
        public async Task<HouseUser?> GetHouseUserById(int id, IList<string> includeProperties = null)
        {
            IQueryable<HouseUser> query = _context.HouseUsers;
            if (includeProperties != null)
                foreach (var prop in includeProperties)
                    query = query.Include(prop);
            var user = await query.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return null;
            return user;
        }
        public async Task<List<HouseUser>?> GetHouseUsersByHouseId(int houseId)
        {
            if (houseId == 0)
                return null;
            return await _context.HouseUsers
                .Where(hu => hu.HouseId == houseId)
                .ToListAsync();
        }
        public async Task<HouseUser?> UpdateHouseUser(int id, HouseUser request)
        {
            var user = await _context.HouseUsers.FindAsync(id);
            if (user == null)
                return null;
            if (request == null)
                return null;
            user.Points = request.Points;
            user.IsAdmin = request.IsAdmin;
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<HouseUser?> DeleteHouseUser(int id)
        {
            var user = await _context.HouseUsers.FindAsync(id);
            if (user == null)
                return null;
            _context.HouseUsers.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
