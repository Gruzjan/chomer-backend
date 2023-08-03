using chomer_backend.Models;

namespace chomer_backend.Services.ChoreService
{
    public interface IChoreService
    {
        Task<List<Chore>> CreateChore(Chore chore);
        Task<List<Chore>> GetChores();
        Task<Chore?> GetChoreById(int id, IList<string> includeProperties = null);
        Task<Chore?> UpdateChore(int id, Chore request);
        Task<List<Chore>?> DeleteChore(int id);

    }
}
