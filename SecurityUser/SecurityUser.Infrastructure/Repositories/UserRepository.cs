using SecurityUser.Core.Entities;
using SecurityUser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUser.Infrastructure.Repositories
{
   public class UserRepository : IUserRepository
    {
       
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = Enumerable.Range(1, 10).Select(x => new User
            {
                UserId = x,
                LoginName = "jmanrique",
                Password = "123",
                Address = "asdasdasd",
                Rol = "Administrador",
                Age = 24,
                Email = "jmanrique@gmail.com",
                Names = "Jose Manrique",
                PhoneNumber ="65156151"
            });
            await Task.Delay(5);
            return  users;
        }
    }
}
