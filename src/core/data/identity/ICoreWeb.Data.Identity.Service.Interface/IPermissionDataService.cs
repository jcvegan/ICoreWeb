using System;
using System.Threading;
using System.Threading.Tasks;

namespace ICoreWeb.Data.Identity.Service.Interface
{
    public interface IPermissionDataService
    {
        Task CreateAsync(
            Guid categoryId,
            string name,
            string description = null,
            CancellationToken cancellationToken = new CancellationToken());
    }
}