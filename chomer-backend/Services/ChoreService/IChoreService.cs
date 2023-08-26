using chomer_backend.Models;

namespace chomer_backend.Services.ChoreService
{
    public interface IChoreService
    {
        Task<Chore> CreateChore(Chore chore);
        Task<List<Chore>> GetChores();
        Task<Chore?> GetChoreById(int id, IList<string> includeProperties = null);
        Task<Chore?> UpdateChore(int id, Chore request);
        Task<Chore?> DeleteChore(int id);

    }
}
