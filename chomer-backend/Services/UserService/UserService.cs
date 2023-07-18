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
        public async Task<List<User>> CreateUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>?> UpdateUser(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            if (request == null)
                return null;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }
    }
}
