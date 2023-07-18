using chomer_backend.Models;

namespace chomer_backend.Services.RewardService
{
    public interface IRewardService
    {
        Task<List<Reward>> CreateReward(Reward reward);
        Task<List<Reward>> GetRewards();
        Task<Reward?> GetRewardById(int id);
        Task<Reward?> UpdateReward(int id, Reward request);
        Task<List<Reward>?> DeleteReward(int id);
    }
}
