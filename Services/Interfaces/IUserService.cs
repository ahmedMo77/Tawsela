using Tawsela.Entities;
using Tawsela.Enums;

namespace Tawsela.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(string fullName, string email, string passwordHash, UserRole role);
        Task<bool> UpdateUserAsync(int id, User updatedUser);
        Task<bool> DeleteUserAsync(int id);
    }
}
