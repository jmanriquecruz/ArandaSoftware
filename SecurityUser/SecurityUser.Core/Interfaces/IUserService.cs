using SecurityUser.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityUser.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<User> GetUserByLogin(User user);
    }
}