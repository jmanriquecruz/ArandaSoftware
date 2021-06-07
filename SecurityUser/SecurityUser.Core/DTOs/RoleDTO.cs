using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityUser.Core.DTOs
{
    public class RoleDTO
    {
        public int IdRole { get; set; }
        public string Name { get; set; }

        List<PermissionDTO> PermissionDTO { get; set; }
    }
}
