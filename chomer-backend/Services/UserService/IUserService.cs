using chomer_backend.Models;

namespace chomer_backend.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> CreateUser(User user);
        Task<List<User>?> UpdateUser(int id, User request);
        Task<List<User>?> DeleteUser(int id);
        Task<User?> GetUserById(int id);
        Task<List<User>> GetUsers();
    }
}
