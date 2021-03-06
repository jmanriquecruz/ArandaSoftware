using SecurityUser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUser.Core.Interfaces
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByLogin(User user);
        Task InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
