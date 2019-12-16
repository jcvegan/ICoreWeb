// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Store.Interface 2019
// IPermissionStore.cs
// Todos los derechos reservados

using System;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Model;

namespace ICoreWeb.Data.Identity.Store.Interface
{
    public interface IPermissionStore
    {
        Task<bool> ExistsPermissionAsync(string name,string categoryName, CancellationToken cancellationToken);

        Task<CorePermission> CreatePermissionAsync(
            string name,
            string description,
            Guid categoryId,
            CancellationToken cancellationToken);
    }
}