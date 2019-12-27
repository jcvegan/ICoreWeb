using System.ComponentModel.DataAnnotations;

namespace ICoreWebApp.Core.Web.Areas.Identity.Models.Api.Roles
{
    public class CreateRoleModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}