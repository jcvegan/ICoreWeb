// Jcvegan.com - Juan Vega
// ICoreWebApp.Core.Web 2019
// PermissionsController.cs
// Todos los derechos reservados

using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Manager;
using ICoreWeb.Data.Identity.Service.Interface;
using ICoreWebApp.Core.Web.Areas.Identity.Models.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace ICoreWebApp.Core.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("[area]/[controller]")]
    public class PermissionsController : Controller
    {
        private readonly IPermissionCategoryDataService _permissionCategoryDataService;
        private readonly IPermissionDataService _permissionDataService;

        public PermissionsController(IPermissionCategoryDataService permissionCategoryDataService, IPermissionDataService permissionDataService)
        {
            _permissionCategoryDataService = permissionCategoryDataService;
            _permissionDataService = permissionDataService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            var model = new CreateModel();

            model.Categories = await _permissionCategoryDataService.GetCategoriesAsync();

            return await Task.Run(() => View(model));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateModel model)
        {
            await _permissionDataService.CreateAsync(model.CategoryId, model.Name, model.Description);
            return await Task.Run(() => RedirectToAction(""));
        }
    }
}