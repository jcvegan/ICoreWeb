// Jcvegan.com - Juan Vega
// ICoreWebApp.Core.Web 2019
// PermissionCategoriesController.cs
// Todos los derechos reservados

using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Manager;
using ICoreWeb.Data.Identity.Service.Interface;
using ICoreWebApp.Core.Web.Areas.Identity.Models.PermissionCategories;
using Microsoft.AspNetCore.Mvc;

namespace ICoreWebApp.Core.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("[area]/Permissions/Categories")]
    public class PermissionCategoriesController : Controller
    {
        private readonly IPermissionCategoryDataService _permissionCategoryDataService;

        public PermissionCategoriesController(IPermissionCategoryDataService permissionCategoryDataService)
        {
            _permissionCategoryDataService = permissionCategoryDataService;
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
            await _permissionCategoryDataService.CreateAsync(model.Name);
            return await Task.Run<IActionResult>(() => RedirectToAction("Index"));
        }
    }
}