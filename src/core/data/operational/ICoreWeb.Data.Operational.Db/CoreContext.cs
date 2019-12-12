// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Operational.Db 2019
// CoreContext.cs
// Todos los derechos reservados

using ICoreWeb.Data.Operational.Db.Interface;
using ICoreWeb.Data.Operational.Model;
using Microsoft.EntityFrameworkCore;

namespace ICoreWeb.Data.Operational.Db
{
    public class CoreContext : DbContext, ISiteContext
    {
        public DbSet<Site> Sites { get; set; }
    }
}