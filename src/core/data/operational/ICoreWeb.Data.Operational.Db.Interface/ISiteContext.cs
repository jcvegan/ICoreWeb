// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Operational.Db.Interface 2019
// ISiteContext.cs
// Todos los derechos reservados

using ICoreWeb.Data.Operational.Model;
using Microsoft.EntityFrameworkCore;

namespace ICoreWeb.Data.Operational.Db.Interface
{
    public interface ISiteContext
    {
        DbSet<Site> Sites { get; set; }
    }
}