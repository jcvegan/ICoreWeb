// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Db 2019
// CoreDbContext.cs
// Todos los derechos reservados

using System;
using ExtCore.Data.Abstractions;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Model.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICoreWeb.Data.Identity.Db.Model
{
    public class CoreDbContext : IdentityDbContext<CoreUser, CoreRole, Guid, CoreUserClaim, CoreUserRole, CoreUserLogin,
        CoreRoleClaim, CoreUserToken>, IStorageContext
    {

        public DbSet<CorePermissionCategory> PermissionCategories { get; set; }
        public DbSet<CorePermission> Permissions { get; set; }

        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CorePermissionDesign());
            builder.ApplyConfiguration(new CorePermissionCategoryDesign());
        }
    }
}