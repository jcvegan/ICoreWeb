using ICoreWeb.Common.Components.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICoreWeb.Common.Components.Components
{

    [ViewComponent(Name = "Title")]
    public class TitleComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string header)
        {
            var model = new TitleModel()
            {
                Header = header
            };
            return View(model);
        }
    }
}