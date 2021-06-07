using SecurityUser.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityUser.Core.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetPermissions();
        Task<IEnumerable<Permission>> GetPermissionByRoleId(int id);

    }
}