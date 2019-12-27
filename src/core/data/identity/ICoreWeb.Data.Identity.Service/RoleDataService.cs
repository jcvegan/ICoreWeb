using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Common.Model.Paging;
using ICoreWeb.Data.Identity.Db.Model;
using ICoreWeb.Data.Identity.Manager;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Service.Interface;
using ICoreWeb.Data.Identity.Service.Model;
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

            var permissions = _dbContext.Permissions.ToListAsync();
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

        public async Task<IEnumerable<Role>> GetRolesAsync(DefaultPageFilterModel paging, CancellationToken cancellationToken = new CancellationToken())
        {
            var rolesFromDb = _dbContext.Roles.AsQueryable();
            cancellationToken.ThrowIfCancellationRequested();
            if (paging != null)
                rolesFromDb = paging.ApplyFilter(rolesFromDb);

            var roles = rolesFromDb.Select(role => new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                CreatedTime = GetCreatedTimeOfRoleById(role.Id)
            });
            return await Task.FromResult(roles.ToList());
        }

        private DateTime GetCreatedTimeOfRoleById(Guid roleId)
        {
            var claim = _dbContext.RoleClaims.FirstOrDefault(claim =>
                claim.RoleId == roleId && claim.ClaimType == "CreatedTime");
            var createdTime = DateTime.Parse(claim.ClaimValue);
            return createdTime;
        }

        public async Task RenameRole(Guid roleId, string newRoleName, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}