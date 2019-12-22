using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ICoreWeb.Common.Components.Engine
{
    public class WebCoreAppView : IView
    {
        private readonly string _viewPath;

        public WebCoreAppView(string viewPath)
        {
            _viewPath = viewPath;
        }

        public async Task RenderAsync(ViewContext context)
        {
            var template = File.ReadAllText(Path);

            await Task.FromResult(context.Writer.WriteAsync(template));
        }

        public string Path => _viewPath;
    }
}