using System.Threading.Tasks;
using ICoreWeb.Data.Common.Model.Paging;
using ICoreWeb.Data.Identity.Service.Interface;
using ICoreWebApp.Core.Web.Areas.Identity.Models.Api.Roles;
using Microsoft.AspNetCore.Mvc;

namespace ICoreWebApp.Core.Web.Areas.Identity.Controllers.Api
{
    [ApiController()]
    [Route("api/roles")]
    public class RolesApiController : Controller
    {
        private readonly IRoleDataService _roleDataService;

        public RolesApiController(IRoleDataService roleDataService)
        {
            _roleDataService = roleDataService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetRoles([FromQuery] DefaultPageFilterModel filterModel)
        {
            var roles = await _roleDataService.GetRolesAsync(filterModel);
            return await Task.Run(() => Json(roles));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            if (!ModelState.IsValid)
                return await Task.Run(BadRequest);

            await _roleDataService.CreateRoleAsync(model.Name, model.Description);
            return await Task.Run(Ok);
        }
    }
}