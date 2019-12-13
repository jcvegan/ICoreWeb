using System;

namespace ICoreWeb.Data.Identity.Model
{
    public class CorePermission
    {
        public Guid Id { get; set; }
        public Guid CateogoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}