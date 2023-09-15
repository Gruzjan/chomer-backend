using chomer_backend.Data;
using chomer_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace chomer_backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetUserById(int id, IList<string> includeProperties = null)
        {
            IQueryable<User> query = _context.Users;
            if (includeProperties != null)
                foreach (var prop in includeProperties)
                    query = query.Include(prop);
            var user = await query.FirstOrDefaultAsync(r => r.Id == id);
            if (user == null)
                return null;
            return user;
        }
        public async Task<User?> UpdateUser(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            if (request == null)
                return null;
            user.Name = request.Name;
            user.Email = request.Email;
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            _context.Houses.RemoveRange(user.Houses);
            _context.HouseUsers.RemoveRange(user.HouseUsers);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
