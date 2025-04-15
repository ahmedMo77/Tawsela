using Tawsela.Entities;
using Tawsela.Services.Interfaces;
using Tawsela.Repositories.Interfaces;
using Tawsela.Enums;
using Tawsela.Patterns;

namespace Tawsela.Services.Implementations
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;


        public UserService(IUserRepository userRepository, IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public async Task<User> CreateUserAsync(string fullName, string email, string passwordHash, UserRole role)
        {
            var user = _userFactory.Create(role, fullName, email, passwordHash);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(int id, User updatedUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            existingUser.FullName = updatedUser.FullName;
            existingUser.Email = updatedUser.Email;
            existingUser.PasswordHash = updatedUser.PasswordHash;
            existingUser.Role = updatedUser.Role;

            await _userRepository.UpdateAsync(existingUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            await _userRepository.DeleteAsync(existingUser);
            return true;
        }
    }


}