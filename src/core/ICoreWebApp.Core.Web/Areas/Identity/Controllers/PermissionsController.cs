// Jcvegan.com - Juan Vega
// ICoreWebApp.Core.Web 2019
// PermissionsController.cs
// Todos los derechos reservados

using ICoreWeb.Data.Identity.Manager;
using Microsoft.AspNetCore.Mvc;

namespace ICoreWebApp.Core.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("[area]/[controller]")]
    public class PermissionsController : Controller
    {
        private readonly CoreRoleManager _roleManager;

        public PermissionsController(CoreRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}