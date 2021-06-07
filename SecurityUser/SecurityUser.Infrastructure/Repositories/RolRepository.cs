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
   public class RoleRepository : IRoleRepository
    {
        private readonly ArandaSoftDBContext _context;
        public RoleRepository(ArandaSoftDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _context.Role.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role = await _context.Role
                        .FirstOrDefaultAsync(x=> x.IdRole == id);

            return role;
        }

      
    }
}
