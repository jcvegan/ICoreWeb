// Jcvegan.com - Juan Vega
// ICoreWebApp.Core.Web 2019
// PermissionCategoriesController.cs
// Todos los derechos reservados

using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Manager;
using ICoreWebApp.Core.Web.Areas.Identity.Models.PermissionCategories;
using Microsoft.AspNetCore.Mvc;

namespace ICoreWebApp.Core.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("[area]/Permissions/Categories")]
    public class PermissionCategoriesController : Controller
    {
        private readonly CoreRoleManager _roleManager;

        public PermissionCategoriesController(CoreRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            await _roleManager.CreatePermissionCategoryAsync(model.Name);
            return await Task.Run<IActionResult>(() => RedirectToAction("Index"));
        }
    }
}