using Microsoft.AspNetCore.Mvc;

namespace ICoreWeb.Common.Components.Components
{
    [ViewComponent(Name = "Sidebar")]
    public class SidebarMenuComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}