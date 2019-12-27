using System.Threading.Tasks;
using ICoreWeb.Data.Common.Model.Paging;
using ICoreWeb.Data.Identity.Service.Interface;
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
    }
}