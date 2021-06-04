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
    }
}
