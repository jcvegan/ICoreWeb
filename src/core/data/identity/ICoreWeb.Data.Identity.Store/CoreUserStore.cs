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
using Microsoft.Extensions.Configuration;

namespace ICoreWeb.Data.Identity.Store
{
    public class CoreUserStore : UserStoreBase<CoreUser, CoreRole, Guid, CoreUserClaim, CoreUserRole, CoreUserLogin, CoreUserToken, CoreRoleClaim>, IUserNameStore<CoreUser> 
    {
        private readonly CoreDbContext _identityDbContext;
        private readonly IConfiguration _configuration;

        public CoreUserStore(IdentityErrorDescriber describer, CoreDbContext identityDbContext, IConfiguration configuration) : base(describer)
        {
            _identityDbContext = identityDbContext;
            _configuration = configuration;
        }
        public CoreUserStore(IdentityErrorDescriber describer) : base(describer)
        {
        }

        public override async Task<IdentityResult> CreateAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            ThrowIfDisposed();

            var result = IdentityResult.Success;

            cancellationToken.ThrowIfCancellationRequested();

            user.Id = Guid.NewGuid();

            using (var transaction = _identityDbContext.Database.BeginTransaction())
            {
                try
                {
                    _identityDbContext.Users.Add(user);

                    var givenNameClaim = await CreateGivenNameClaimAsync(user, cancellationToken);

                    if(givenNameClaim != null)
                        _identityDbContext.UserClaims.Add(givenNameClaim);

                    var familyNameClaim = await CreateFamilyNameClaimAsync(user, cancellationToken);

                    if(familyNameClaim != null)
                        _identityDbContext.UserClaims.Add(familyNameClaim);

                    await _identityDbContext.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                }
                catch (Exception exc)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    result = IdentityResult.Failed(new IdentityError[]
                    {
                        new IdentityError(){}
                    });
                }
            }
            

            return await Task.FromResult(result);
        }

        public override Task<IdentityResult> UpdateAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<IdentityResult> DeleteAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<CoreUser> FindByIdAsync(string userId, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override async Task<CoreUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = new CancellationToken())
        {
            ThrowIfDisposed();

            cancellationToken.ThrowIfCancellationRequested();

            var user = await _identityDbContext.Users.FirstOrDefaultAsync(user =>
                user.NormalizedUserName == normalizedUserName, cancellationToken: cancellationToken);

            return await Task.FromResult(user);
        }

        protected override Task<CoreUser> FindUserAsync(Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<CoreUserLogin> FindUserLoginAsync(Guid userId, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<CoreUserLogin> FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<Claim>> GetClaimsAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task AddClaimsAsync(CoreUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task ReplaceClaimAsync(CoreUser user, Claim claim, Claim newClaim,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task RemoveClaimsAsync(CoreUser user, IEnumerable<Claim> claims,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<IList<CoreUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        protected override Task<CoreUserToken> FindTokenAsync(CoreUser user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task AddUserTokenAsync(CoreUserToken token)
        {
            throw new NotImplementedException();
        }

        protected override Task RemoveUserTokenAsync(CoreUserToken token)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<CoreUser> Users => _identityDbContext.Users.AsQueryable();

        public override Task AddLoginAsync(CoreUser user, UserLoginInfo login, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task RemoveLoginAsync(CoreUser user, string loginProvider, string providerKey,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<CoreUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<bool> IsInRoleAsync(CoreUser user, string normalizedRoleName,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        protected override Task<CoreRole> FindRoleAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<CoreUserRole> FindUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<CoreUser>> GetUsersInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task AddToRoleAsync(CoreUser user, string normalizedRoleName,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task RemoveFromRoleAsync(CoreUser user, string normalizedRoleName,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<IList<string>> GetRolesAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFirstNameAsync(CoreUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetFirstNameAsync(CoreUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetLastNameAsync(CoreUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> SetLastNameAsync(CoreUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFullName(CoreUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        private async Task<CoreUserClaim> CreateGivenNameClaimAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var createdTime = DateTime.UtcNow;

            var givenNameClaim = new CoreUserClaim();

            givenNameClaim.UserId = user.Id;
            givenNameClaim.ClaimType = "given_name";
            givenNameClaim.ClaimValue = user.FirstName;
            givenNameClaim.CreatedTime = createdTime;
            givenNameClaim.LastUpdatedTme = createdTime;

            return givenNameClaim;
        }
        private async Task<CoreUserClaim> CreateFamilyNameClaimAsync(CoreUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var createdTime = DateTime.UtcNow;

            var familyNameClaim = new CoreUserClaim();

            familyNameClaim.UserId = user.Id;
            familyNameClaim.ClaimType = "family_name";
            familyNameClaim.ClaimValue = user.LastName;
            familyNameClaim.CreatedTime = createdTime;
            familyNameClaim.LastUpdatedTme = createdTime;

            return familyNameClaim;
        }
    }
}