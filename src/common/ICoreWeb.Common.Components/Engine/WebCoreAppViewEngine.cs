using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ICoreWeb.Common.Components.Engine
{
    public class WebCoreAppViewEngine : IViewEngine
    {
        private readonly IWebHostEnvironment _environment;

        public WebCoreAppViewEngine(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        private string _componentContainerPath = "Components";
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            var componentRelativePath = Path.Combine(_environment.ContentRootPath,_componentContainerPath, viewName);

            if(!IsComponent(viewName))
                return ViewEngineResult.NotFound(viewName,new []{ componentRelativePath });

            var viewPath = Path.Combine(_componentContainerPath, $"{GetViewName(viewName)}.cshtml");

            if(File.Exists(viewPath))
                return ViewEngineResult.Found(viewName, new WebCoreAppView(viewPath));
            else
                return ViewEngineResult.NotFound(viewName,new []{ viewPath });
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            var componentRelativePath = Path.Combine(_componentContainerPath, viewPath);

            if(!File.Exists(componentRelativePath))
                return ViewEngineResult.NotFound(viewPath,new []{ componentRelativePath });

            return ViewEngineResult.Found(viewPath, new WebCoreAppView(componentRelativePath));
        }

        private bool IsComponent(string viewName)
        {
            return viewName.StartsWith("Components");
        }

        private string GetViewName(string viewName)
        {
            var paths = viewName.Split("/");
            return paths[1];
        }
    }
}