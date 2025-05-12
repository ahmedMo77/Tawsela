using Tawsela.Entities;
using Tawsela.Enums;
using Tawsela.Services.Implementations;

namespace Tawsela.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(CreateUserRequest userReq);
        Task<bool> UpdateUserAsync(int id, User updatedUser);
        Task<bool> DeleteUserAsync(int id);
    }
}
