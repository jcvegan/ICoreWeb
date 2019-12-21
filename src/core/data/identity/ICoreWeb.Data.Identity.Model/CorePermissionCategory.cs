using System;
using System.Collections.Generic;

namespace ICoreWeb.Data.Identity.Model
{
    public class CorePermissionCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }

        public virtual IEnumerable<CorePermission> Permissions { get; set; }
    }
}