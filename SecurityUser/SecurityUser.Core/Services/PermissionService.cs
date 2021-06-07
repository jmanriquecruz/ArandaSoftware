using SecurityUser.Core.Entities;
using SecurityUser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUser.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository PermissionRepository)
        {
            _permissionRepository = PermissionRepository;
        }

        public async Task<IEnumerable<Permission>> GetPermissions()
        {

            return await _permissionRepository.GetPermissions();
        }

        public async Task<IEnumerable<Permission>> GetPermissionByRoleId(int id)
        {
            return await _permissionRepository.GetPermissionByRoleId(id);
        }
    }
}
