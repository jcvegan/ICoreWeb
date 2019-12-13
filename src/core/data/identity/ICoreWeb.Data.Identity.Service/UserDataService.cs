using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Service.Interface;
using ICoreWeb.Data.Identity.Service.Model;
using Microsoft.AspNetCore.Identity;

namespace ICoreWeb.Data.Identity.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly UserManager<CoreUser> _userManager;

        public UserDataService(UserManager<CoreUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task CreateUserAsync(User newUser, string password)
        {
            
        }
    }
}