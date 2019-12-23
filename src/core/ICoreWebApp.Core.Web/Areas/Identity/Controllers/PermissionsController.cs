using System;
using System.Threading.Tasks;
using ICoreWeb.Data.Common.Model.Paging;
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
        public async Task<IActionResult> Index([FromQuery]int size = 50,[FromQuery] int page = 1)
        {
            var filter = new DefaultPageFilterModel {PageSize = size, CurrentPage = page};
            return await Task.Run(async () => View(await _permissionDataService.GetPermissionsAsync(filter)));
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

        [HttpGet("{id}")]
        public async Task<IActionResult> View(Guid id)
        {
            var permission = await _permissionDataService.GetPermissionByIdAsync(id);
            return await Task.Run(() => View(permission));
        }
    }
}