using Microsoft.EntityFrameworkCore;
using SecurityUser.Core.Entities;
using SecurityUser.Core.Interfaces;
using SecurityUser.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUser.Infrastructure.Repositories
{
   public class UserRepository : IUserRepository
    {
        private readonly ArandaSoftDBContext _context;
        public UserRepository(ArandaSoftDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            return  users;
        }

        public async Task InsertUser(User user )
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.User.Include(u=>u.IdRoleNavigation).FirstOrDefaultAsync(x=> x.IdUser == id);

            return user;
        }

        public async Task<User> GetUserByLogin(User user)
        {
            var login = await _context.User.Include(u => u.IdRoleNavigation).FirstOrDefaultAsync(x => x.LoginName == user.LoginName && x.Password == user.Password);

            return login;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var currentUser = await GetUserById(user.IdUser);
            currentUser.Names = user.Names;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.Email = user.Email;
            currentUser.Age = user.Age;
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var currentUser = await GetUserById(id);
            _context.Remove(currentUser);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
