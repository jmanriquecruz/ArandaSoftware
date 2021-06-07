using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityUser.Core.DTOs
{
    public class PermissionDTO
    {
        public int IdPermission { get; set; }
        public string PermissionType { get; set; }

        public bool Value { get; set; }

    }
}
