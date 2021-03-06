﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Manager.Interface;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Store.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ICoreWeb.Data.Identity.Manager
{
    public class CoreRoleManager : RoleManager<CoreRole>, ICoreRoleManager, IPermissionManager {
        
        public CoreRoleManager(
            IRoleStore<CoreRole> store,
            IEnumerable<IRoleValidator<CoreRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<CoreRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {

        }

        public override Task<IdentityResult> CreateAsync(CoreRole role)
        {
            return base.CreateAsync(role);
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

        public IQueryable<CorePermissionCategory> Categories => CoreStore.PermissionCategory;

        internal ICoreRoleStore CoreStore => (ICoreRoleStore) base.Store;
        public async Task<CorePermission> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            return await CoreStore.GetPermissionByIdAsync(id, cancellationToken);
        }
    }
}