// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Manager.Interface 2019
// ICoreRoleManager.cs
// Todos los derechos reservados

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ICoreWeb.Data.Identity.Manager.Interface
{
    public interface ICoreRoleManager
    {
        Task<IdentityResult> CreatePermissionAsync(
            string name,
            string description,
            string categoryName,
            CancellationToken cancellationToken);
    }
}