// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Model 2019
// CoreUserClaim.cs
// Todos los derechos reservados

using System;
using Microsoft.AspNetCore.Identity;

namespace ICoreWeb.Data.Identity.Model
{
    public class CoreUserClaim : IdentityUserClaim<Guid>
    {
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTme { get; set; }
    }
}