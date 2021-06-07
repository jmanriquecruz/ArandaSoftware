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
   public class PermissionRepository : IPermissionRepository
    {
        private readonly ArandaSoftDBContext _context;
        public PermissionRepository(ArandaSoftDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            var roles = await _context.Permission.ToListAsync();
            return roles;
        }

        public async Task<IEnumerable<Permission>> GetPermissionByRoleId(int id)
        {
            var permissions = await _context.Permission.
                        Include(u => u.RolePermission).ToListAsync();
            permissions = permissions.Where(x => x.RolePermission.Any(u => u.IdRole == id)).ToList();

            return permissions;
        }

      
    }
}
