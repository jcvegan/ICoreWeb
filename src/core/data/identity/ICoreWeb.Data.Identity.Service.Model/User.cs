using System;

namespace ICoreWeb.Data.Identity.Service.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrincipalEmail { get; set; }
        public string PrincipalPhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
