using System;

namespace ICoreWeb.Data.Identity.Model
{
    public class CoreRolePermission
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool Grant { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}