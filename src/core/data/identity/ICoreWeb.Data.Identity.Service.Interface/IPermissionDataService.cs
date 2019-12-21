using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ICoreWeb.Data.Common.Model.Paging;
using ICoreWeb.Data.Identity.Model;

namespace ICoreWeb.Data.Identity.Service.Interface
{
    public interface IPermissionDataService
    {
        Task CreateAsync(
            Guid categoryId,
            string name,
            string description = null,
            CancellationToken cancellationToken = new CancellationToken());

        Task<IQueryable<CorePermission>> GetPermissionsAsync(
            PageFilterModel filter,
            CancellationToken cancellationToken = new CancellationToken());
    }
}