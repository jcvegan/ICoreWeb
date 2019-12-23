using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Common.Model.Paging;
using ICoreWeb.Data.Identity.Db.Model;
using ICoreWeb.Data.Identity.Manager;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ICoreWeb.Data.Identity.Service
{
    public class PermissionDataService : IPermissionDataService
    {
        private readonly CoreRoleManager _coreRoleManager;
        private readonly CoreDbContext _dbContext;

        public PermissionDataService(CoreRoleManager coreRoleManager, CoreDbContext dbContext)
        {
            _coreRoleManager = coreRoleManager;
            _dbContext = dbContext;
        }

        public async Task CreateAsync(
            Guid categoryId,
            string name,
            string description = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var category = await _dbContext.PermissionCategories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if(category == null)
                throw new ArgumentNullException();

            var now = DateTime.UtcNow;

            var permission = new CorePermission()
            {
                Name = name,
                CateogoryId = categoryId,
                LastUpdatedTime = now,
                CreatedTime = now,
                Id = Guid.NewGuid(),
                Description = description
            };

            _dbContext.Permissions.Add(permission);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<CorePermission>> GetPermissionsAsync(PageFilterModel filter, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Task.FromResult(filter.ApplyFilter(_dbContext.Permissions.Include(x => x.Category).AsQueryable()));
        }

        public async Task<CorePermission> GetPermissionByIdAsync(Guid permissionId, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _coreRoleManager.GetPermissionByIdAsync(permissionId, cancellationToken);
        }
    }
}