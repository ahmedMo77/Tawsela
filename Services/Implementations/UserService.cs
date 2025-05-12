using Tawsela.Entities;
using Tawsela.Services.Interfaces;
using Tawsela.Repositories.Interfaces;
using Tawsela.Enums;
using Tawsela.Patterns;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Tawsela.Repositories.Implementations;

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


        //  Before Refactoring
        //public async Task<User> CreateUserAsync(string fullName, string email, string passwordHash, UserRole role)
        //{
        //    var user = _userFactory.Create(role, fullName, email, passwordHash);

        //    await _userRepository.AddAsync(user);
        //    await _userRepository.SaveChangesAsync();

        //    return user;
        //}


        // after refactoring
        public async Task<User> CreateUserAsync(CreateUserRequest userReq)
        {
            var user = _userFactory.Create(userReq.Role, userReq.FullName, userReq.Email, userReq.PasswordHash);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }


        // before factoring
        //public async Task<User?> GetUserByIdAsync(int id)
        //{
        //    return await _userRepository.GetByIdAsync(id);
        //}

        //  after refactoring
        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            return user;
        }




        // Before Refactoring!!
        //public async Task<bool> UpdateUserAsync(int id, User updatedUser)
        //{
        //    var existingUser = await _userRepository.GetByIdAsync(id);
        //    if (existingUser == null)
        //        return false;

        //    existingUser.FullName = updatedUser.FullName;
        //    existingUser.Email = updatedUser.Email;
        //    existingUser.PasswordHash = updatedUser.PasswordHash;
        //    existingUser.Role = updatedUser.Role;

        //    await _userRepository.UpdateAsync(existingUser);
        //    return true;
        //}


        // after refactoring
        public async Task<bool> UpdateUserAsync(int id, User updatedUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            ApplyUserUpdates(existingUser, updatedUser);

            await _userRepository.UpdateAsync(existingUser);
            return true;
        }

        private void ApplyUserUpdates(User existingUser, User updatedUser)
        {
            existingUser.FullName = updatedUser.FullName;
            existingUser.Email = updatedUser.Email;
            existingUser.PasswordHash = updatedUser.PasswordHash;
            existingUser.Role = updatedUser.Role;
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



    // new class to refactoring
    public class CreateUserRequest
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }
    
    }


}