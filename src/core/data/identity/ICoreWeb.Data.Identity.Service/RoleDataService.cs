using System;
using System.Collections.Generic;
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
    public class RoleDataService : IRoleDataService
    {
        private readonly CoreRoleManager _roleManager;
        private readonly CoreDbContext _dbContext;

        public RoleDataService(CoreRoleManager roleManager, CoreDbContext dbContext)
        {
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task CreateRoleAsync(string roleName, string description = "", CancellationToken cancellationToken = new CancellationToken())
        {
            var createdTime = DateTime.UtcNow;

            var role = new CoreRole()
            {
                Id = Guid.NewGuid(),
                Name = roleName,
                Description = description,
                NormalizedName = roleName.Normalize(),
            };

            cancellationToken.ThrowIfCancellationRequested();

            var roleResult = await _roleManager.CreateAsync(role);

            if (roleResult.Succeeded)
            {
                _dbContext.RoleClaims.Add(new CoreRoleClaim()
                    {ClaimType = "RoleName", ClaimValue = role.Name, RoleId = role.Id});
                _dbContext.RoleClaims.Add(new CoreRoleClaim()
                    {ClaimType = "RoleDescription", ClaimValue = role.Description, RoleId = role.Id});
                _dbContext.RoleClaims.Add(new CoreRoleClaim()
                    {ClaimType = "CreatedTime", ClaimValue = createdTime.ToString("yyyy-MM-dd hh:mm:ss.fffZ"), RoleId = role.Id});
                _dbContext.RoleClaims.Add(new CoreRoleClaim()
                    {ClaimType = "LastUpdatedTime", ClaimValue = createdTime.ToString("yyyy-MM-dd hh:mm:ss.fffZ"), RoleId = role.Id});
                _dbContext.RoleClaims.Add(new CoreRoleClaim()
                    {ClaimType = "UsersInRole", ClaimValue = "0", RoleId = role.Id});
                _dbContext.RoleClaims.Add(new CoreRoleClaim()
                    {ClaimType = "PermissionsInRole", ClaimValue = "0", RoleId = role.Id});
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
                
        }

        public async Task<CoreRole> GetRoleByIdAsync(Guid roleId, CancellationToken cancellationToken = new CancellationToken())
        {
            var role = _dbContext.Roles.FirstOrDefaultAsync(role => role.Id == roleId);
            cancellationToken.ThrowIfCancellationRequested();
            return await role;
        }

        public async Task<CoreRole> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken = new CancellationToken())
        {
            var role = _dbContext.Roles.FirstOrDefaultAsync(role => role.Name == roleName);
            cancellationToken.ThrowIfCancellationRequested();
            return await role;
        }

        public async Task<bool> ExistRoleByIdAsync(Guid roleId, CancellationToken cancellationToken = new CancellationToken())
        {
            var existRole = _dbContext.Roles.AnyAsync(role => role.Id == roleId);
            cancellationToken.ThrowIfCancellationRequested();
            return await existRole;
        }

        public async Task<bool> ExistRoleByNameAsync(string roleName, CancellationToken cancellationToken = new CancellationToken())
        {
            var existRole = _dbContext.Roles.AnyAsync(role => role.Name == roleName);
            cancellationToken.ThrowIfCancellationRequested();
            return await existRole;
        }

        public async Task<IEnumerable<CoreRole>> GetRolesAsync(DefaultPageFilterModel paging, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _dbContext.Roles.ToListAsync(cancellationToken);
        }

        public async Task RenameRole(Guid roleId, string newRoleName, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}