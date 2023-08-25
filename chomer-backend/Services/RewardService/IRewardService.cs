using chomer_backend.Models;

namespace chomer_backend.Services.RewardService
{
    public interface IRewardService
    {
        Task<Reward> CreateReward(Reward reward);
        Task<List<Reward>> GetRewards();
        Task<Reward?> GetRewardById(int id, IList<string> includeProperties = null);
        Task<Reward?> UpdateReward(int id, Reward request);
        Task<Reward?> DeleteReward(int id);
    }
}
