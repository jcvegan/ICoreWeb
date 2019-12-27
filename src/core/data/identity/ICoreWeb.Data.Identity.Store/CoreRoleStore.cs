
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Db.Model;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Store.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ICoreWeb.Data.Identity.Store
{
    public class CoreRoleStore : RoleStoreBase<CoreRole, Guid, CoreUserRole, CoreRoleClaim>, ICoreRoleStore
    {
        private readonly CoreDbContext _dbContext;
        public CoreRoleStore(CoreDbContext dbContext, IdentityErrorDescriber describer) : base(describer)
        {
            _dbContext = dbContext;
        }
        public override async Task<IdentityResult> CreateAsync(CoreRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            var existingRole = await FindByNameAsync(role.Name.Normalize(), cancellationToken);
            if(existingRole != null)
                return IdentityResult.Failed(new IdentityError(){Code = "ERRROLE001",Description = "The name of the role already exist"});

            if(role.Id == Guid.Empty)
                role.Id = Guid.NewGuid();

            cancellationToken.ThrowIfCancellationRequested();

            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public override async Task<IdentityResult> UpdateAsync(CoreRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override async Task<IdentityResult> DeleteAsync(CoreRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override async Task<CoreRole> FindByIdAsync(string id, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override async Task<CoreRole> FindByNameAsync(string normalizedName, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            var role = _dbContext.Roles.FirstOrDefaultAsync(role => role.NormalizedName == normalizedName);
            return await role;
        }

        public override async Task<IList<Claim>> GetClaimsAsync(CoreRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override async Task AddClaimAsync(CoreRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override async Task RemoveClaimAsync(CoreRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override IQueryable<CoreRole> Roles { get; }
        public async Task<bool> ExistsCategoryAsync(string categoryName, CancellationToken cancellationToken)
        {
            return await _dbContext.PermissionCategories.AnyAsync(category => category.Name == categoryName, cancellationToken);
        }

        public async Task<CorePermissionCategory> GetCategorPermissionyByNameAsync(string categoryName, CancellationToken cancellationToken)
        {
            return await _dbContext.PermissionCategories.FirstOrDefaultAsync(category => category.Name == categoryName, cancellationToken);
        }

        public async Task<CorePermissionCategory> CreateCategorPermissionyByNameAsync(string categoryName, CancellationToken cancellationToken = new CancellationToken())
        {
            var createdTime = DateTime.UtcNow;

            var category = new CorePermissionCategory()
            {
                Id = Guid.NewGuid(),
                CreatedTime = createdTime,
                LastUpdatedTime = createdTime,
                Name = categoryName
            };

            _dbContext.PermissionCategories.Add(category);

            var recordsAffected = await _dbContext.SaveChangesAsync(cancellationToken);

            if (recordsAffected == 0)
                category = null;

            return await Task.FromResult<CorePermissionCategory>(category);

        }

        public IQueryable<CorePermissionCategory> PermissionCategory => _dbContext.PermissionCategories.AsQueryable();

        public async Task<bool> ExistsPermissionAsync(string name, string categoryName, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ExistsCategoryAsync(categoryName, cancellationToken);
        }

        public async Task<CorePermission> CreatePermissionAsync(string name, string description, Guid categoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CorePermission> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var permission = _dbContext.Permissions
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

            return await permission;
        }
    }
}