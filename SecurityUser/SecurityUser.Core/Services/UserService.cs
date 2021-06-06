using SecurityUser.Core.Entities;
using SecurityUser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUser.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task InsertUser(User user)
        {
             await _userRepository.InsertUser(user);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> GetUserByLogin(User user)
        {
            return await _userRepository.GetUserByLogin(user);
        }
    }
}
