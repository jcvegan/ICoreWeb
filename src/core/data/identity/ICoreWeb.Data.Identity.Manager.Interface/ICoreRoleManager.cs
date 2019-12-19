// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Manager.Interface 2019
// ICoreRoleManager.cs
// Todos los derechos reservados

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Model;
using Microsoft.AspNetCore.Identity;

namespace ICoreWeb.Data.Identity.Manager.Interface
{
    public interface ICoreRoleManager
    {
        Task<IdentityResult> CreatePermissionCategoryAsync(string categoryName,
            CancellationToken cancellationToken = new CancellationToken());
        Task<IdentityResult> CreatePermissionAsync(
            string name,
            string description,
            string categoryName,
            CancellationToken cancellationToken);

        Task<bool> ExistsCategoryAsync(
            string name,
            CancellationToken cancellationToken = new CancellationToken());

        Task CreateCategoryAsync(
            string name,
            CancellationToken cancellationToken = new CancellationToken());

        IQueryable<CorePermissionCategory> Categories { get; }
    }
}