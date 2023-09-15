using chomer_backend.Models;

namespace chomer_backend.Services.UserService
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(int id, IList<string> includeProperties = null);
        Task<User?> UpdateUser(int id, User request);
        Task<User?> DeleteUser(int id);
    }
}
