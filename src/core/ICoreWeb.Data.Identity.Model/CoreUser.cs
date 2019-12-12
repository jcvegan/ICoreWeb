// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Model 2019
// CoreUser.cs
// Todos los derechos reservados

using System;
using Microsoft.AspNetCore.Identity;

namespace ICoreWeb.Data.Identity.Model
{
    public class CoreUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int IdentificationDocumentTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string CountryId { get; set; }
    }
}