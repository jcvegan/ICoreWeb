// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Store.Interface 2019
// ICoreRoleStore.cs
// Todos los derechos reservados

using ICoreWeb.Data.Identity.Model;
using Microsoft.AspNetCore.Identity;

namespace ICoreWeb.Data.Identity.Store.Interface
{
    public interface ICoreRoleStore : IRoleStore<CoreRole>, ICategoryPermissionStore, IPermissionStore
    {
        
    }
}