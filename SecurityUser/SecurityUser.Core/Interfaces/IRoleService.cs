using SecurityUser.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityUser.Core.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleById(int id);

    }
}