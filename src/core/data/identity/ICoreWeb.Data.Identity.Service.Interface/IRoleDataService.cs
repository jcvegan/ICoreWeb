using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Common.Model.Paging;
using ICoreWeb.Data.Identity.Model;

namespace ICoreWeb.Data.Identity.Service.Interface
{
    public interface IRoleDataService
    {
        Task CreateRoleAsync(string roleName, string description = "", CancellationToken cancellationToken = new CancellationToken());
        Task<CoreRole> GetRoleByIdAsync(Guid roleId, CancellationToken cancellationToken = new CancellationToken());
        Task<CoreRole> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken = new CancellationToken());
        Task<bool> ExistRoleByIdAsync(Guid roleId, CancellationToken cancellationToken = new CancellationToken());
        Task<bool> ExistRoleByNameAsync(string roleName, CancellationToken cancellationToken = new CancellationToken());

        Task<IEnumerable<CoreRole>> GetRolesAsync(
            DefaultPageFilterModel paging,
            CancellationToken cancellationToken = new CancellationToken());

        Task RenameRole(Guid roleId, string newRoleName, CancellationToken cancellationToken = new CancellationToken());
    }
}