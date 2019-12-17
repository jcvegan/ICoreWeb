// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Service 2019
// PermissionCategoryDataService.cs
// Todos los derechos reservados

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Manager;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Service.Interface;

namespace ICoreWeb.Data.Identity.Service
{
    public class PermissionCategoryDataService : IPermissionCategoryDataService
    {
        private readonly CoreRoleManager _coreRoleManager;

        public PermissionCategoryDataService(CoreRoleManager coreRoleManager)
        {
            _coreRoleManager = coreRoleManager;
        }

        public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _coreRoleManager.ExistsCategoryAsync(name, cancellationToken);
        }

        public async Task CreateAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var exists = await ExistsAsync(name, cancellationToken);
            if (!exists)
                await _coreRoleManager.CreateCategoryAsync(name, cancellationToken);
        }

        public async Task<IEnumerable<CorePermissionCategory>> GetCategoriesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}