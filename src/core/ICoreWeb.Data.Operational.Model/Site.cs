// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Operational.Model 2019
// Site.cs
// Todos los derechos reservados

using System;

namespace ICoreWeb.Data.Operational.Model
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
    }
}