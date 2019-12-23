using ICoreWeb.Data.Identity.Model;
using Microsoft.AspNetCore.Identity;

namespace ICoreWeb.Data.Identity.Store.Interface
{
    public interface ICoreRoleStore : IRoleStore<CoreRole>, ICategoryPermissionStore, IPermissionStore
    {
        
    }
}