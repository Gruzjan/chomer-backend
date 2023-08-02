using chomer_backend.Data;
using chomer_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chomer_backend.Services.ChoreService
{
    public class ChoreService : IChoreService
    {
        private readonly DataContext _context;
        public ChoreService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Chore>> CreateChore(Chore chore)
        {
            _context.Chores.Add(chore);
            await _context.SaveChangesAsync();
            return await _context.Chores.ToListAsync();
        }
        public async Task<Chore?> GetChoreById(int id, IList<string> includeProperties = null)
        {
            var query = _context.Chores;
            if (includeProperties != null)
                foreach (var prop in includeProperties)
                    query.Include(prop);
            var chore = await query.FirstOrDefaultAsync(c => c.Id == id);
            if (chore == null)
                return null;
            return chore;
        }

        public async Task<List<Chore>> GetChores()
        {
            return await _context.Chores.ToListAsync();
        }

        public async Task<Chore?> UpdateChore(int id, Chore request)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
                return null;
            chore.Name = request.Name;
            chore.Description = request.Description;
            chore.Value = request.Value;
            chore.AssignedToId = request.AssignedToId;
            await _context.SaveChangesAsync();
            return chore;
        }
        public async Task<List<Chore>?> DeleteChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
                return null;
            _context.Chores.Remove(chore);
            await _context.SaveChangesAsync();
            return await _context.Chores.ToListAsync();
        }
    }
}
