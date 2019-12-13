using System;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Service.Model;

namespace ICoreWeb.Data.Identity.Service.Interface
{
    public interface IUserDataService
    {
        Task CreateUserAsync(User newUser, string password);
    }
}