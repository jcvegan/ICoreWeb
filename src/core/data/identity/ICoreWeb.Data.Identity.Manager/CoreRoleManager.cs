// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Manager 2019
// CoreRoleManager.cs
// Todos los derechos reservados

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Manager.Interface;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Store.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ICoreWeb.Data.Identity.Manager
{
    public class CoreRoleManager : RoleManager<CoreRole>, ICoreRoleManager {
        
        public CoreRoleManager(
            IRoleStore<CoreRole> store,
            IEnumerable<IRoleValidator<CoreRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<CoreRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {

        }

        public async Task<IdentityResult> CreatePermissionCategoryAsync(string categoryName, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var existsCategory = await CoreStore.ExistsCategoryAsync(categoryName, cancellationToken);

                if (!existsCategory)
                    await CoreStore.CreateCategorPermissionyByNameAsync(categoryName, cancellationToken);

                return await Task.FromResult(IdentityResult.Success);
            }
            catch (Exception exc)
            {
                return await Task.FromResult(IdentityResult.Failed());
            }
        }

        public async Task<IdentityResult> CreatePermissionAsync(string name, string description, string categoryName, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();

            CorePermissionCategory category = null;

            var existsCategory = await CoreStore.ExistsCategoryAsync(categoryName, cancellationToken);

            if (existsCategory)
                category = await CoreStore.GetCategorPermissionyByNameAsync(categoryName, cancellationToken);
            else
                category = await CoreStore.CreateCategorPermissionyByNameAsync(categoryName, cancellationToken);


            return await Task.FromResult(IdentityResult.Success);

        }

        public async Task<bool> ExistsCategoryAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await CoreStore.ExistsCategoryAsync(name, cancellationToken);

        }

        public async Task CreateCategoryAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            await CoreStore.CreateCategorPermissionyByNameAsync(name, cancellationToken);
        }

        internal ICoreRoleStore CoreStore => (ICoreRoleStore) base.Store;
    }
}