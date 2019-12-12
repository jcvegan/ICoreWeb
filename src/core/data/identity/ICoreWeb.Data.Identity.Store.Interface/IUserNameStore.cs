using System.Threading;
using System.Threading.Tasks;

namespace ICoreWeb.Data.Identity.Store.Interface
{
    public interface IUserNameStore<TUser>
    {
        Task<string> GetFirstNameAsync(TUser user, CancellationToken cancellationToken);
        Task SetFirstNameAsync(TUser user, CancellationToken cancellationToken);
        Task<string> GetLastNameAsync(TUser user, CancellationToken cancellationToken);
        Task<string> SetLastNameAsync(TUser user, CancellationToken cancellationToken);
        Task<string> GetFullName(TUser user, CancellationToken cancellationToken);
    }
}