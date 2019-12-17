// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Service.Initializer 2019
// ServiceInitializer.cs
// Todos los derechos reservados

using System;
using Foil;
using ICoreWeb.Data.Identity.Db.Model;
using ICoreWeb.Data.Identity.Manager;
using ICoreWeb.Data.Identity.Model;
using ICoreWeb.Data.Identity.Service.Initializer.Logging;
using ICoreWeb.Data.Identity.Store;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ICoreWeb.Data.Identity.Service.Initializer
{
    public static class ServiceInitializer
    {
        public static IServiceCollection AddCoreService(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<CoreDbContext>(options);

            services.AddIdentity<CoreUser,CoreRole>().AddEntityFrameworkStores<CoreDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransientWithInterception<IUserStore<CoreUser>, CoreUserStore>(m => m.InterceptBy<LoggingFact>());
            services.AddTransientWithInterception<IRoleStore<CoreRole>, CoreRoleStore>(m => m.InterceptBy<LoggingFact>());
            services.AddTransientWithInterception<CoreRoleManager,CoreRoleManager>(m => m.InterceptBy<LoggingFact>());
            return services;
        }
    }
}