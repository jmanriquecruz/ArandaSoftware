using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SecurityUser.Core.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermission = new HashSet<RolePermission>();
        }
 
        public int IdPermission { get; set; }
        public string PermissionType { get; set; }

        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
