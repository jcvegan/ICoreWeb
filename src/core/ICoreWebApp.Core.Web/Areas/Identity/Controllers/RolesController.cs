using Microsoft.AspNetCore.Mvc;

namespace ICoreWebApp.Core.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RolesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}