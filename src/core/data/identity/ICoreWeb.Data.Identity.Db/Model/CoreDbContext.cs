// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Db 2019
// CoreDbContext.cs
// Todos los derechos reservados

using System;
using ExtCore.Data.Abstractions;
using ICoreWeb.Data.Identity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICoreWeb.Data.Identity.Db.Model
{
    public class CoreDbContext : IdentityDbContext<CoreUser, CoreRole, Guid, CoreUserClaim, CoreUserRole, CoreUserLogin,
        CoreRoleClaim, CoreUserToken>, IStorageContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
            
        }
    }
}