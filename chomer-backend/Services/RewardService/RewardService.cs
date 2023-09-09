using chomer_backend.Data;
using chomer_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace chomer_backend.Services.RewardService
{
    public class RewardService : IRewardService
    {
        private readonly DataContext _context;
        public RewardService(DataContext context)
        {
            _context = context;
        }
        public async Task<Reward> CreateReward(Reward reward)
        {
            await _context.AddAsync(reward);
            await _context.SaveChangesAsync();
            return reward;
        }
        public async Task<List<Reward>> GetRewards()
        {
            return await _context.Rewards.ToListAsync();
        }
        public async Task<Reward?> GetRewardById(int id, IList<string> includeProperties = null)
        {
            IQueryable<Reward> query = _context.Rewards;
            if (includeProperties != null)
                foreach (var prop in includeProperties)
                    query = query.Include(prop);
            var reward = await query.FirstOrDefaultAsync(r => r.Id == id);
            if (reward == null)
                return null;
            return reward;
        }
        public async Task<Reward?> UpdateReward(int id, Reward request)
        {
            var reward = await _context.Rewards.FindAsync(id);
            if (reward == null)
                return null;
            reward.Name = request.Name;
            reward.Cost = request.Cost;
            reward.Quantity = request.Quantity;
            await _context.SaveChangesAsync();
            return reward;
        }
        public async Task<Reward?> DeleteReward(int id)
        {
            var reward = await _context.Rewards.FindAsync(id);
            if (reward == null)
                return null;
            _context.Rewards.Remove(reward);
            await _context.SaveChangesAsync();
            return reward;
        }
    }
}
