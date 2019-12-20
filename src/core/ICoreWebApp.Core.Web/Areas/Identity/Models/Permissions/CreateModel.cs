using System;
using System.Collections.Generic;
using ICoreWeb.Data.Identity.Model;

namespace ICoreWebApp.Core.Web.Areas.Identity.Models.Permissions
{
    public class CreateModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<CorePermissionCategory> Categories { get; set; }
        
    }
}