// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Store.Interface 2019
// ICategoryPermissionStore.cs
// Todos los derechos reservados

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Model;

namespace ICoreWeb.Data.Identity.Store.Interface
{
    public interface ICategoryPermissionStore
    {
        Task<bool> ExistsCategoryAsync(string categoryName, CancellationToken cancellationToken = new CancellationToken());
        Task<CorePermissionCategory> GetCategorPermissionyByNameAsync(string categoryName, CancellationToken cancellationToken = new CancellationToken());
        Task<CorePermissionCategory> CreateCategorPermissionyByNameAsync(string categoryName, CancellationToken cancellationToken = new CancellationToken());

        IQueryable<CorePermissionCategory> PermissionCategory { get; }
    }
}